import { useTranslation } from "react-i18next";
import { Grid } from '@mui/material';
import { useReducer } from 'react';
import { GridRow } from '../../Components/gridRow';
import { InputField } from '../../Components/InputField/inputField';
import { GridContainer } from "../../Components/gridContainer";
import supplierService from "./supplierService";
import { DefaultAlert } from "../../Components/Alert/alert";
import { DefaultDataGrid, TableHeader } from "../../Components/DataGrid/dataGrid";
import { DefaultSelect } from "../../Components/Select/select";
import { IconSwitch } from "../../Components/IconSwitch/iconSwitch";
import { SaveClearSearchBtnRow } from "../../Components/Button/saveClearSearchBtnRow";

export function Supplier() {
    const { t } = useTranslation();

    const columns = [
        { field: 'name', renderHeader: (params) => <TableHeader {...params} />, flex: 1 },
        { field: 'email', renderHeader: (params) => <TableHeader {...params} />, flex: 1 },
        { field: 'ddd', renderHeader: (params) => <TableHeader {...params} />, flex: 1 },
        { field: 'phone', renderHeader: (params) => <TableHeader {...params} />, flex: 1 },
        { field: 'createdDate', renderHeader: (params) => <TableHeader {...params} />, flex: 1 },
        { field: 'lastUpdatedDate', renderHeader: (params) => <TableHeader {...params} />, flex: 1 },
        {
            field: 'status',
            renderHeader: (params) => <TableHeader {...params} />,
            flex: 1,
            renderCell: (params) => (
                params.value === 1 ? <IconSwitch icon="check" /> : <IconSwitch icon="close" />
            ),
        },
    ];



    const reducer = (state, action) => {
        switch (action.type) {
            case "update":
                return { ...state, ...action.data }
            case "clear":
                return { ...initialState }
            case "success":
                return { ...initialState, message: t(action.data), success: true, error: false }
            case "successWithData":
                return { ...state, ...action.data, success: true, error: false }
            case "error":
                return { ...state, message: t(action.data), success: false, error: true }
            default:
                throw new Error;
        }
    }

    const initialState = {
        id: 0,
        name: "",
        email: "",
        ddd: "",
        phone: "",
        status: 2,
        error: false,
        success: false,
        message: "",
        rows: [],
    }

    const [state, dispatch] = useReducer(reducer, initialState)
    const { id, name, email, ddd, phone, status } = state
    const { success, error, message, rows, ...data } = state

    const handleChange = ({ target: { name, value } }) => {
        dispatch({ type: "update", data: { [name]: value } })
    }

    const handleInsertUpdate = async () => {
        try {
            if (id !== 0) {
                const response = await supplierService.update(data);
                if (response.status === 200) {
                    dispatch({ type: "success", data: "successUpdate" });
                }
            } else {
                const response = await supplierService.insert(data);
                if (response.status === 200) {
                    dispatch({ type: "success", data: "successInsert" });
                }
            }
        } catch (error) {
            console.error("Error inserting/updating data:", error);
            dispatch({ type: "error", data: "errorInsertUpdate" });
        }
    };

    const handleSearch = async () => {
        try {
            const response = await supplierService.get(data);
            if (response.status === 200) {
                dispatch({ type: "successWithData", data: { message: t("successSearch"), rows: response.data } });
            }
        } catch (error) {
            console.error("Error searching data:", error);
            dispatch({ type: "error", data: "errorSearch" });
        }
    };

    const onRowClick = (data) => {
        dispatch({ type: "update", data: { ...data } })
    }

    return (
        <GridContainer>
            <GridRow>
                <Grid item md={2}>
                    <InputField
                        name={"name"}
                        value={name}
                        onChange={handleChange}
                    />
                </Grid>
                <Grid item md={2}>
                    <InputField
                        name={"email"}
                        value={email}
                        onChange={handleChange}
                    />
                </Grid>
                <Grid item md={1}>
                    <InputField
                        name={"ddd"}
                        value={ddd}
                        onChange={handleChange}
                    />
                </Grid>
                <Grid item md={2}>
                    <InputField
                        name={"phone"}
                        value={phone}
                        onChange={handleChange}
                    />
                </Grid>
                <Grid item md={2}>
                    <DefaultSelect
                        name={"status"}
                        value={status}
                        onChange={handleChange}
                        isStatus
                    />
                </Grid>
            </GridRow>
            <SaveClearSearchBtnRow
                save={() => handleInsertUpdate()}
                clear={() => dispatch({ type: "clear" })}
                search={() => handleSearch()}
            />
            <GridRow>
                <DefaultAlert
                    success={success}
                    error={error}
                    message={message} />
            </GridRow>
            {rows.length > 0 ? (
                <DefaultDataGrid
                    columns={columns}
                    rows={rows}
                    onRowClick={onRowClick}
                />
            ) : null}

        </GridContainer>
    )
}