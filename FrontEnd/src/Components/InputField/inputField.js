import { Grid, InputAdornment, TextField, Typography } from "@mui/material";
import { useTranslation } from "react-i18next";

export function InputField(
    { name,
        value,
        onChange,
        required,
        disabled,
        placeholder,
        type,
        readOnly,
        defaultValue,
        helperText,
        maxLength,
        error,
        multiline,
        maxRows,
        rows,
        adornment,
        startAdornment }) {

    const { t } = useTranslation();



    return (
        <div>
            <Grid>
                <Typography>{t(name)}</Typography>
            </Grid>
            <Grid>
                <TextField
                    fullWidth
                    name={name}
                    value={value}
                    onChange={onChange}
                    variant="outlined"
                    required={required}
                    disabled={disabled}
                    placeholder={placeholder}
                    type={type} //password ; number ; search ;
                    InputProps={{
                        readOnly: readOnly,
                        maxLength: maxLength,
                        startAdornment: startAdornment ? (<InputAdornment position="start">{adornment}</InputAdornment>) : null
                    }}
                    defaultValue={defaultValue}
                    helperText={helperText}
                    error={error}
                    multiline={multiline}
                    maxRows={maxRows}
                    rows={rows}
                />
            </Grid>
        </div>
    )
}