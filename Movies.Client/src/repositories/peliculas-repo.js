import axios from 'axios'

let api_url = 'http://localhost:5000/api/v1';

class PeliculasRepo {
    obtenerPeliculas() {
        return axios.get(`${ api_url }/peliculas`);
    }

    obtenerPelicula(id) {
        return axios.get(`${ api_url }/peliculas/${ id }`);
    }

    guardarPelicula(pelicula) {
        return axios.post(`${ api_url }/peliculas`, pelicula);
    }
}

export default new PeliculasRepo();