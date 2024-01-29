import { Grid } from '@mui/material';
import { DataGrid } from '@mui/x-data-grid';

export function DefaultDataGrid({ rows, columns, onRowClick }) {
    return (
        <Grid style={{ height: 550, width: '100%' }}>
            <DataGrid
                rows={rows}
                columns={columns}
                onRowClick={(data) => onRowClick(data.row)} />
        </Grid>
    );
}