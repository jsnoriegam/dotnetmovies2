import axios from 'axios'

class PeliculasRepo {
    obtenerTodas() {
        return axios.get(`${ movies.api_url }/peliculas`);
    }

    obtenerUna(id) {
        return axios.get(`${ movies.api_url }/peliculas/${ id }`);
    }

    agregar(pelicula) {
        return axios.post(`${ movies.api_url }/peliculas`, pelicula);
    }

    modificar(id, pelicula) {
        return axios.put(`${ movies.api_url }/peliculas/${ id }`, pelicula);
    }

    eliminar(id,) {
        return axios.delete(`${ movies.api_url }/peliculas/${ id }`);
    }
}

export default new PeliculasRepo();