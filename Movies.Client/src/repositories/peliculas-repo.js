import axios from 'axios'

let api_url = 'http://localhost:5000/api/v1';

class PeliculasRepo {
    obtenerTodas() {
        return axios.get(`${ api_url }/peliculas`);
    }

    obtenerUna(id) {
        return axios.get(`${ api_url }/peliculas/${ id }`);
    }

    agregar(pelicula) {
        return axios.post(`${ api_url }/peliculas`, pelicula);
    }

    modificar(id, pelicula) {
        return axios.put(`${ api_url }/peliculas/${ id }`, pelicula);
    }

    eliminar(id,) {
        return axios.delete(`${ api_url }/peliculas/${ id }`);
    }
}

export default new PeliculasRepo();