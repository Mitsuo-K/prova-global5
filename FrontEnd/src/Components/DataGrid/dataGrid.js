import { Grid, Typography } from '@mui/material';
import { DataGrid, GridToolbar } from '@mui/x-data-grid';
import { t } from 'i18next';
import PropTypes from 'prop-types';

DefaultDataGrid.propTypes = {
    rows: PropTypes.array.isRequired,
    columns: PropTypes.array.isRequired,
    onRowClick: PropTypes.func,
};

export const TableHeader = ({ field, label }) => (
    <Typography fontWeight="bold">
        {t(field)}
    </Typography>
);

export function DefaultDataGrid({ rows, columns, onRowClick }) {
    const gridStyle = {
        height: 550,
        width: '100%',
    };

    return (
        <Grid style={gridStyle}>
            <DataGrid
                rows={rows}
                columns={columns}
                onRowClick={(data) => onRowClick(data.row)}
                slots={{ toolbar: GridToolbar }}
            />
        </Grid>
    );
}