import { Box, Grid, Typography } from '@mui/material';
import { useReducer } from 'react';
import { GridRow } from '../../Components/gridRow';
import { InputField } from '../../Components/InputField/inputField';
import { useTranslation } from "react-i18next";
import './home.scss'

export function Home() {
    const { t } = useTranslation();

    const reducer = (state, action) => {
        switch (action.type) {
            case "update":
                return { ...state, ...action.data }
            default:
                throw new Error;
        }

    }

    const initialState = {
        field1: "",
    }

    const [state, dispatch] = useReducer(reducer, initialState)
    const { field1 } = state

    const handleChange = ({ target: { name, value } }) => {
        dispatch({ type: "update", data: { [name]: value } })
    }

    return (
        <GridRow>
            <Grid item sm={12} md={12}>
                <Grid item>
                    <Grid item sm={12}>
                        <Typography>{t("field1")}</Typography>
                        <InputField
                            name={"field1"}
                            value={field1}
                            onChange={handleChange} />

                    </Grid>
                </Grid>
                <Grid item>
                    <Typography>@ Desenvolvido por MitsuoK</Typography>
                </Grid>
            </Grid>
        </GridRow>
    )
}