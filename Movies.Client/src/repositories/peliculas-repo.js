import axios from 'axios'
import config from '../services/config'

class PeliculasRepo {
    obtenerPeliculas() {
        return axios.get(`${ config.apiUrl() }/peliculas`);
    }

    obtenerPelicula(id) {
        return axios.get(`${ config.apiUrl() }/peliculas/${ id }`);
    }

    guardarPelicula(pelicula) {
        return axios.post(`${ config.apiUrl() }/peliculas`, pelicula);
    }
}

export default new PeliculasRepo();