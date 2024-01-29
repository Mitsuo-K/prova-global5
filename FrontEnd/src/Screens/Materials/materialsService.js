import http from "../../Configurations/http-common";

const insert = (data) => { return http.post('/Materials/InsertMaterial', data) };
const update = (data) => { return http.put('/Materials/UpdateMaterial', data) };
const get = (data) => { return http.post('/Materials/GetMaterials', data) };

export default { insert, update, get };