import Alert from '@mui/material/Alert';

export function DefaultAlert(props) {
    return (
        <div style={{ display: 'flex', justifyContent: 'center' }}>
            {props.success ? (
                <Alert severity="success">{props.message}</Alert>
            ) : props.error ? (
                <Alert severity="error">{props.message}</Alert>
            ) : props.warning ? (
                <Alert severity="warning">{props.message}</Alert>
            ) : null}
        </div>
    )
}