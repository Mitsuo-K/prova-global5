import { useEffect, useReducer } from 'react';
import { useTranslation } from "react-i18next";
import { GridContainer } from '../../Components/gridContainer';
import { DefaultDataGrid, TableHeader } from '../../Components/DataGrid/dataGrid';
import homeService from './homeService';
import { DefaultSelect } from '../../Components/Select/select';
import { GridRow } from '../../Components/gridRow';
import { Grid } from '@mui/material';
import { IconSwitch } from '../../Components/IconSwitch/iconSwitch';

export function Home() {
    const { t } = useTranslation();

    const columns = [
        { field: 'supplierName', renderHeader: (params) => <TableHeader {...params} />, flex: 1 },
        { field: 'materialName', renderHeader: (params) => <TableHeader {...params} />, flex: 1 },
        { field: 'oldQtty', renderHeader: (params) => <TableHeader {...params} />, flex: 1 },
        { field: 'newQtty', renderHeader: (params) => <TableHeader {...params} />, flex: 1 },
        {
            field: 'movimentation', renderHeader: (params) => <TableHeader {...params} />, flex: 1,
            renderCell: (params) => {
                return t(params.value);
            }
        },
        { field: 'createdDate', renderHeader: (params) => <TableHeader {...params} />, flex: 1 },
        {
            field: 'status', renderHeader: (params) => <TableHeader {...params} />, flex: 1,
            renderCell: (params) => {
                return params.value === 1 ? <IconSwitch icon={"check"} /> : <IconSwitch icon={"close"} />;
            }
        },
    ];

    const reducer = (state, action) => {
        switch (action.type) {
            case "update":
                return { ...state, ...action.data }
            default:
                throw new Error;
        }

    }

    const initialState = {
        status: 2,
        rows: [],
    }

    const [state, dispatch] = useReducer(reducer, initialState)
    const { status } = state
    const { rows, ...data } = state

    const handleChange = ({ target: { name, value } }) => {
        dispatch({ type: "update", data: { [name]: value } })
    }

    useEffect(() => {
        const fetchData = async () => {
            try {
                const getStockHistResponse = await homeService.getStockHist(data);
                if (getStockHistResponse.status === 200) {
                    dispatch({ type: "update", data: { rows: getStockHistResponse.data } });
                }
            } catch (error) {
                console.error("Error fetching data:", error);
            }
        }
        fetchData()
    }, [status]);

    return (

        <GridContainer>
            <GridRow>
                <Grid item md={2}>
                    <DefaultSelect
                        name={"status"}
                        value={status}
                        onChange={handleChange}
                        isStatus
                    />
                </Grid>
            </GridRow>
            <DefaultDataGrid
                rows={rows}
                columns={columns}
            />
        </GridContainer>
    )
}