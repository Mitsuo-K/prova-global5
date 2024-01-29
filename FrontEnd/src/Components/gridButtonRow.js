import { Grid } from "@mui/material";

export const GridButtonRow = (props) => (
    <Grid
        style={{
            padding: 20,
        }}
        item
        container
        spacing={3}
        direction="row"
        justify="flex-start"
        alignItems="center"
    >
        {props.children}
    </Grid>
);