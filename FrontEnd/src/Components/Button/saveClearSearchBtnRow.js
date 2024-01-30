import { Grid } from "@mui/material";
import { DefaultButton } from "./button";
import { GridButtonRow } from "../gridButtonRow";
import PropTypes from 'prop-types';

SaveClearSearchBtnRow.propTypes = {
    save: PropTypes.func,
    clear: PropTypes.func,
    search: PropTypes.func,
};

export function SaveClearSearchBtnRow({ save, clear, search }) {

    return (
        <GridButtonRow>
            <Grid item>
                <DefaultButton
                    onClick={save}
                    icon={"save"}
                />
            </Grid>
            <Grid item>
                <DefaultButton
                    onClick={clear}
                    icon={"clear"}
                />
            </Grid>
            <Grid item>
                <DefaultButton
                    onClick={search}
                    icon={"search"}
                />
            </Grid>
        </GridButtonRow>
    )
}