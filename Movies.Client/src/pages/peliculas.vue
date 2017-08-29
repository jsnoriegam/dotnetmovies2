<template>
    <div>
        <h3>Películas</h3>
        <div class="row" v-if="showForm">
        </div>
        <div class="row">
            <div class="col">
                <table class="table">
                    <thead>
                        <tr>
                            <th>#</th>
                            <th>Nombre</th>
                            <th>Codigo IMDB</th>
                            <th>Resumen</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr v-for="pelicula, i in peliculas">
                            <td>{{ i + 1 }}</td>
                            <td>{{ pelicula.nombre }}</td>
                            <td>{{ pelicula.codigoIMDB }}</td>
                            <td>{{ pelicula.resumen }}</td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
</template>

<script>
import peliculasRepo from '../repositories/peliculas-repo'

function obtenerPeliculas() {
    peliculasRepo.obtenerPeliculas().then(response => {
        this.peliculas = response.data;
    }).catch(error => {
        alert("Ocurrió un error descargando el listado de películas");
    });
}

export default {
    data() {
        return {
            showFrom: false,
            peliculas: []
        }
    },
    created() {
        obtenerPeliculas.call(this);
    }
}
</script>
