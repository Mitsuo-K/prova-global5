import { useTranslation } from "react-i18next";
import { Grid } from '@mui/material';
import { useReducer } from 'react';
import { GridRow } from '../../Components/gridRow';
import { InputField } from '../../Components/InputField/inputField';
import { GridContainer } from "../../Components/gridContainer";
import { DefaultButton } from "../../Components/Button/button";
import { GridButtonRow } from "../../Components/gridButtonRow";
import materialsService from "./materialsService";
import { DefaultAlert } from "../../Components/Alert/alert";
import { DefaultDataGrid, TableHeader } from "../../Components/DataGrid/dataGrid";
import { DefaultSelect } from "../../Components/Select/select";
import { IconSwitch } from "../../Components/IconSwitch/iconSwitch";

export function Materials() {
    const moment = require('moment');
    const { t } = useTranslation();

    const columns = [
        { field: 'name', renderHeader: (params) => <TableHeader {...params} />, flex: 1 },
        { field: 'code', renderHeader: (params) => <TableHeader {...params} />, flex: 1 },
        { field: 'dueDate', renderHeader: (params) => <TableHeader {...params} />, flex: 1 },
        { field: 'createdDate', renderHeader: (params) => <TableHeader {...params} />, flex: 1 },
        { field: 'lastUpdatedDate', renderHeader: (params) => <TableHeader {...params} />, flex: 1 },
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
        code: "",
        dueDate: moment().format("YYYY-MM-DD"),
        status: 2,
        error: false,
        success: false,
        message: "",
        rows: [],
    }

    const [state, dispatch] = useReducer(reducer, initialState)
    const { id, name, code, dueDate, status } = state
    const { success, error, message, rows, ...data } = state

    const handleChange = ({ target: { name, value } }) => {
        dispatch({ type: "update", data: { [name]: value } })
    }

    const handleInsertUpdate = async () => {
        const sendData = { ...data, dueDate: moment(dueDate).format() }
        try {
            if (id !== 0) {
                const response = await materialsService.update(sendData);
                if (response.status === 200) {
                    dispatch({ type: "success", data: "successUpdate" });
                }
            } else {
                const response = await materialsService.insert(sendData);
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
            const response = await materialsService.get(data);
            if (response.status === 200) {
                dispatch({ type: "successWithData", data: { message: t("successSearch"), rows: response.data } });
            }
        } catch (error) {
            console.error("Error searching data:", error);
            dispatch({ type: "error", data: "errorSearch" });
        }
    };

    const onRowClick = (data) => {
        const newData = { ...data, dueDate: moment(data.dueDate).format("YYYY-MM-DD") }
        dispatch({ type: "update", data: { ...newData } })
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
                        name={"code"}
                        value={code}
                        onChange={handleChange}
                    />
                </Grid>
                <Grid item md={2}>
                    <InputField
                        type={"date"}
                        name={"dueDate"}
                        value={dueDate}
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
            <GridButtonRow>
                <Grid item>
                    <DefaultButton
                        onClick={() => handleInsertUpdate()}
                        icon={"save"}
                    />
                </Grid>
                <Grid item>
                    <DefaultButton
                        onClick={() => dispatch({ type: "clear" })}
                        icon={"clear"}
                    />
                </Grid>
                <Grid item>
                    <DefaultButton
                        onClick={() => handleSearch()}
                        icon={"search"}
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