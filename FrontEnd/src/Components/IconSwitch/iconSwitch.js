import SaveIcon from '@mui/icons-material/Save';
import BackspaceIcon from '@mui/icons-material/Backspace';
import SearchIcon from '@mui/icons-material/Search';
import CheckIcon from '@mui/icons-material/Check';
import CloseIcon from '@mui/icons-material/Close';

export const IconSwitch = ({ icon, color, size }) => {
    const getIcon = () => {
        switch (icon) {
            case "save":
                return <SaveIcon color={color} fontSize={size} />;
            case "clear":
                return <BackspaceIcon color={color} fontSize={size} />;
            case "search":
                return <SearchIcon color={color} fontSize={size} />;
            case "check":
                return <CheckIcon color={color} fontSize={size} />;
            case "close":
                return <CloseIcon color={color} fontSize={size} />;
            default:
                return null;
        }
    };

    return getIcon();
};