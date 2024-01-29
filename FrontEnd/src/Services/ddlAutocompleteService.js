import http from "../Configurations/http-common";

const getSupplierList = () => { return http.get('/DDLCentral/GetSupplierList') };
const getMaterialsList = () => { return http.get('/DDLCentral/GetMaterialsList') };

export default {
    getSupplierList,
    getMaterialsList
};