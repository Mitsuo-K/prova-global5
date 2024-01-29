import http from "../../Configurations/http-common";

const insert = (data) => { return http.post('/Stock/InsertStock', data) };
const update = (data) => { return http.put('/Stock/UpdateStock', data) };
const get = (data) => { return http.post('/Stock/GetStock', data) };

export default { insert, update, get };