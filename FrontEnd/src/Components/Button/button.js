import { Button } from "@mui/material";
import { useTranslation } from "react-i18next";
import PropTypes from 'prop-types';
import { IconSwitch } from "../IconSwitch/iconSwitch";

DefaultButton.propTypes = {
    onClick: PropTypes.func.isRequired,
    label: PropTypes.func,
    icon: PropTypes.string,
};

export function DefaultButton({ onClick, label, icon }) {
    const { t } = useTranslation();
    return (
        <div>
            <Button
                onClick={onClick}
                style={{
                    backgroundColor: "#000000",
                    height: 40,
                    minWidth: 120,
                    color: "#FFF",
                    "&:hover": {
                        backgroundColor: "#333333",
                    },
                }
                }>
                {icon ? <IconSwitch icon={icon} /> : t(label)}
            </Button>
        </div>
    )
}