import { Grid, MenuItem, Select, Typography } from "@mui/material";
import { useTranslation } from "react-i18next";

export function DefaultSelect({ name, value, items, onChange, isStatus, label }) {
    const { t } = useTranslation()

    const statusItems = [
        { value: 0, label: t("canceled") },
        { value: 1, label: t("active") },
        { value: 2, label: t("all") },
    ];

    return (
        <>
            <Grid>
                <Typography fontWeight={"bold"}>{label ? t(label) : t(name)}</Typography>
            </Grid>
            <Grid>
                <Select
                    fullWidth
                    value={value}
                    label={name}
                    defaultValue={0}
                    onChange={(event) => onChange({ target: { name: name, value: event.target.value } })}
                >
                    {isStatus
                        ? statusItems.map((item) => (
                            <MenuItem key={item.value} value={item.value}>
                                {item.label}
                            </MenuItem>
                        ))
                        :
                        items.map((item) => (
                            <MenuItem key={item.id} value={item.id}>
                                {`${t(item.name)}${item.status === 0 ? "(" + t("canceled") + ")" : ""}`}
                            </MenuItem>
                        ))}
                </Select>
            </Grid>
        </>
    )
}