import { useTranslation } from "react-i18next";
import { Grid } from '@mui/material';
import { useReducer } from 'react';
import { GridRow } from '../../Components/gridRow';
import { InputField } from '../../Components/InputField/inputField';
import { GridContainer } from "../../Components/gridContainer";
import { DefaultButton } from "../../Components/Button/button";
import { GridButtonRow } from "../../Components/gridButtonRow";
import supplierService from "./supplierService";
import { DefaultAlert } from "../../Components/Alert/alert";
import { DefaultDataGrid } from "../../Components/DataGrid/dataGrid";

export function Supplier() {
    const { t } = useTranslation();

    const columns = [
        { field: 'name', headerName: t('name'), flex: 1 },
        { field: 'email', headerName: t('email'), flex: 1 },
        { field: 'ddd', headerName: t('ddd'), flex: 1 },
        { field: 'phone', headerName: t('phone'), flex: 1 },
        { field: 'createdDate', headerName: t('createdDate'), flex: 1 },
        { field: 'lastUpdatedDate', headerName: t('lastUpdatedDate'), flex: 1 },
        { field: 'status', headerName: t('status'), flex: 1 },
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
        status: 1,
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

    const handleInsertUpdate = () => {
        if (id != 0) {
            supplierService
                .update(data)
                .then((response) => {
                    if (response.status === 200) {
                        dispatch({ type: "success", data: "successUpdate" })
                    }
                }).catch((e) => {
                    dispatch({ type: "error", data: "errorUpdate" })
                })
        } else {
            supplierService
                .insert(data)
                .then((response) => {
                    if (response.status === 200) {
                        dispatch({ type: "success", data: "successInsert" })
                    }
                }).catch((e) => {
                    dispatch({ type: "error", data: "errorInsert" })
                })
        }
    }

    const handleSearch = () => {
        supplierService
            .get(data)
            .then((response) => {
                if (response.status === 200) {
                    dispatch({ type: "successWithData", data: { message: "successSearch", rows: response.data } })
                }
            }).catch((e) => {
                dispatch({ type: "error", data: "errorSearch" })
            })
    }

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
                <Grid item md={1}>
                    <InputField
                        name={"status"}
                        value={status}
                        onChange={handleChange}
                    />
                </Grid>
            </GridRow>
            <GridButtonRow>
                <Grid item>
                    <DefaultButton
                        onClick={() => handleInsertUpdate()}
                        label={t("save")}
                    />
                </Grid>
                <Grid item>
                    <DefaultButton
                        onClick={() => dispatch({ type: "clear" })}
                        label={t("clear")}
                    />
                </Grid>
                <Grid item>
                    <DefaultButton
                        onClick={() => handleSearch()}
                        label={t("search")}
                    />
                </Grid>
            </GridButtonRow>
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