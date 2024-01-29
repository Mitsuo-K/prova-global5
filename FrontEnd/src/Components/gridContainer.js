import { Grid } from "@mui/material"

export const GridContainer = props => {
    return (
        <div
            style={{
                padding: 20,
            }}
            container
            columnSpacing={3}
            spacing={1}
            {...props}
        >
            {props.children}
        </div>
    );
};