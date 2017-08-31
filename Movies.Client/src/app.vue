<template>
    <div>
        <nav class="navbar navbar-expand-lg navbar-dark bg-dark">
            <div class="container">
                <router-link :to="{ name: 'dashboard' }" class="navbar-brand">PELÍCULAS DB</router-link>
                <template v-if="estaAutenticado()">
                    <ul class="navbar-nav mr-auto">
                        <li class="nav-item"><router-link :to="{ name: 'peliculas' }" class="nav-link">Películas</router-link></li>
                        <li class="nav-item"><router-link :to="{ name: 'personas' }" class="nav-link">Personas</router-link></li>
                    </ul>
                    <ul class="nav navbar-nav">
                        <li class="nav-item"><a href="" class="nav-link" @click.prevent="logout">Logout</a></li>
                    </ul>
                </template>
            </div>
        </nav>
        <div id="content" class="container">
            <router-view></router-view>
        </div>
    </div>
</template>

<script>
import authService from './services/auth-service'

export default {
    data() {
        return {

        }
    },
    methods: {
        logout() {
            authService.cerrarSesion();
            this.$router.push({ name: 'login' });
        },
        estaAutenticado() {
            return authService.tokenValido();
        }
    },
    created() {
        
    }
}
</script>
