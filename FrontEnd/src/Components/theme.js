import { createTheme } from '@mui/material';

const fallbackTheme = createTheme(); // Use default MUI theme as a fallback

export const defaultTheme = createTheme({
    palette: {
        primary: {
            main: "#000000",
        },
        secondary: {
            main: "#ffffff",
        },
    },
}) || fallbackTheme;