import { useEffect, useReducer } from 'react';
import { useTranslation } from "react-i18next";
import { GridContainer } from '../../Components/gridContainer';
import { DefaultDataGrid } from '../../Components/DataGrid/dataGrid';
import homeService from './homeService';
import CheckIcon from '@mui/icons-material/Check';
import CloseIcon from '@mui/icons-material/Close';
import { DefaultSelect } from '../../Components/Select/select';
import { GridRow } from '../../Components/gridRow';
import { Grid } from '@mui/material';


export function Home() {
    const { t } = useTranslation();

    const columns = [
        { field: 'supplierName', headerName: t('supplier'), flex: 1 },
        { field: 'materialName', headerName: t('material'), flex: 1 },
        { field: 'oldQtty', headerName: t('oldQtty'), flex: 1 },
        { field: 'newQtty', headerName: t('newQtty'), flex: 1 },
        { field: 'createdDate', headerName: t('createdDate'), flex: 1 },
        {
            field: 'status', headerName: t('status'), flex: 1,
            renderCell: (params) => {
                return params.value === 1 ? <CheckIcon /> : <CloseIcon />;
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
        rows: "",
    }

    const [state, dispatch] = useReducer(reducer, initialState)
    const { status } = state
    const { rows, ...data } = state

    const handleChange = ({ target: { name, value } }) => {
        dispatch({ type: "update", data: { [name]: value } })
    }

    useEffect(() => {
        homeService
            .getStockHist(data)
            .then((response) => {
                if (response.status === 200) {
                    dispatch({ type: "update", data: { rows: response.data } })
                }
            })

    }, [status])

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