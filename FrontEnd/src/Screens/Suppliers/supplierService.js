import http from "../../Configurations/http-common";

const insert = (data) => { return http.post('/Supplier/InsertSupplier', data) };
const update = (data) => { return http.put('/Supplier/UpdateSupplier', data) };
const get = (data) => { return http.post('/Supplier/GetSupplier', data) };

export default { insert, update, get };