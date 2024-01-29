import { Grid } from '@mui/material';
import { DataGrid } from '@mui/x-data-grid';



export function DefaultDataGrid(props) {
    return (
        <Grid style={{ height: 550, width: '100%' }}>
            <DataGrid
                rows={props.rows}
                columns={props.columns}
                onRowClick={(data) => props.onRowClick(data.row)} />
        </Grid>
    );
}