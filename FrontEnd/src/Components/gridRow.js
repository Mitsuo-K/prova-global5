import { Grid } from "@mui/material"

export function GridRow({ direction, justifyContent, alignItems, children }) {
    return (
        <Grid container
            direction={direction ? direction : "row"}
            justifyContent={justifyContent ? justifyContent : "flex-start"}
            alignItems={alignItems ? alignItems : "flex-start"}
            spacing={2}>
            {children}
        </Grid>
    )
}