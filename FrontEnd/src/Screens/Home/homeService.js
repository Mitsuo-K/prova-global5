import http from "../../Configurations/http-common";

const getStockHist = (data) => { return http.post('/Stock/GetStockHist', data) };

export default { getStockHist };

