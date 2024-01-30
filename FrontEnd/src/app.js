import './app.scss';
import { ThemeProvider } from '@mui/material';
import { RoutesSys } from './Components/routes';
import { defaultTheme } from './Components/theme';

export function App() {
  return (
    <div>
      <ThemeProvider theme={defaultTheme}>
        <RoutesSys />
      </ThemeProvider>
    </div>
  );
}