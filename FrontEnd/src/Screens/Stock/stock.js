import { useTranslation } from "react-i18next";
import { Grid } from '@mui/material';
import { useEffect, useReducer } from 'react';
import { GridRow } from '../../Components/gridRow';
import { InputField } from '../../Components/InputField/inputField';
import { GridContainer } from "../../Components/gridContainer";
import { DefaultButton } from "../../Components/Button/button";
import { GridButtonRow } from "../../Components/gridButtonRow";
import stockService from "./stockService";
import { DefaultAlert } from "../../Components/Alert/alert";
import { DefaultDataGrid } from "../../Components/DataGrid/dataGrid";
import { DefaultSelect } from "../../Components/Select/select";
import ddlAutocompleteService from "../../Services/ddlAutocompleteService";
import CheckIcon from '@mui/icons-material/Check';
import CloseIcon from '@mui/icons-material/Close';
export function Stock() {
    const { t } = useTranslation();

    const columns = [
        { field: 'supplierName', headerName: t('supplier'), flex: 1 },
        { field: 'materialName', headerName: t('material'), flex: 1 },
        { field: 'qtty', headerName: t('qtty'), flex: 1 },
        { field: 'createdDate', headerName: t('createdDate'), flex: 1 },
        { field: 'lastUpdatedDate', headerName: t('lastUpdatedDate'), flex: 1 },
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
            case "clear":
                return { ...initialState, materialsList: state.materialsList, suppliersList: state.suppliersList }
            case "success":
                return { ...initialState, materialsList: state.materialsList, suppliersList: state.suppliersList, message: t(action.data), success: true, error: false }
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
        materialId: 0,
        supplierId: 0,
        qtty: 0,
        status: 2,
        error: false,
        success: false,
        message: "",
        rows: [],
        materialsList: [],
        suppliersList: [],
    }

    const [state, dispatch] = useReducer(reducer, initialState)
    const { id, materialId, supplierId, qtty, status } = state
    const { success, error, message, rows, materialsList, suppliersList, ...data } = state

    useEffect(() => {
        ddlAutocompleteService
            .getMaterialsList()
            .then((response) => {
                if (response.status === 200) {
                    dispatch({ type: "update", data: { materialsList: response.data } })
                }
            })

        ddlAutocompleteService
            .getSupplierList()
            .then((response) => {
                if (response.status === 200) {
                    dispatch({ type: "update", data: { suppliersList: response.data } })
                }
            })
    }, [])

    const handleChange = ({ target: { name, value } }) => {
        dispatch({ type: "update", data: { [name]: value } })
    }

    const handleInsertUpdate = () => {
        if (id != 0) {
            stockService
                .update(data)
                .then((response) => {
                    if (response.status === 200) {
                        dispatch({ type: "success", data: "successUpdate" })
                    }
                }).catch((e) => {
                    dispatch({ type: "error", data: "errorUpdate" })
                })
        } else {
            stockService
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
        stockService
            .get(data)
            .then((response) => {
                if (response.status === 200) {
                    dispatch({ type: "successWithData", data: { message: t("successSearch"), rows: response.data } })
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
                    <DefaultSelect
                        name={"materialId"}
                        value={materialId}
                        label={"material"}
                        onChange={handleChange}
                        items={materialsList}
                    />
                </Grid>
                <Grid item md={2}>
                    <DefaultSelect
                        name={"supplierId"}
                        value={supplierId}
                        label={"supplier"}
                        onChange={handleChange}
                        items={suppliersList}
                    />
                </Grid>
                <Grid item md={2}>
                    <InputField
                        type={"number"}
                        name={"qtty"}
                        value={qtty}
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