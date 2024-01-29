import { Button } from "@mui/material";
import { useTranslation } from "react-i18next";

export function DefaultButton(props) {
    const { t } = useTranslation();

    return (
        <div>
            <Button
                onClick={props.onClick}
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
                {props.label}
            </Button>
        </div>
    )
}