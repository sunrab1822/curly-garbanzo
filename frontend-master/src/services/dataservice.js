import Axios from 'axios';
Axios.defaults.baseURL = 'http://localhost:3000';

export default {
    getAllCategory(){
        return Axios.get('/brands')
            .then(resp => {
                //console.log(resp.data);
                return resp.data;
            })
            .catch(err =>{
                //console.log(err);
                return Promise.reject(err);
            })
    },
    getByID(id){
        return Axios.get(`/watches?brandId=${id}`)
            .then(resp => {
                //console.log(resp.data);
                return resp.data;
            })
            .catch(err =>{
                //console.log(err);
                return Promise.reject(err);
            })
    },
    getwatches(page){
        return Axios.get(`/watches?_page=${page}`)
    },
    saveUser(user){
        return Axios.post('/users',user).then(()=>{});
    },
    updateUser(user,id){
        return Axios.put(`/users/${id}`,user).then(()=>{});
    }


}