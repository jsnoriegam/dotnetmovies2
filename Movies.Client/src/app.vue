<template>
    <div>
        <nav class="navbar navbar-expand-lg navbar-light bg-light">
            <div class="container">
                <router-link :to="{ name: 'dashboard' }" class="navbar-brand">PELÍCULAS DB</router-link>
                <ul class="navbar-nav mr-auto">
                    <li class="nav-item"><router-link :to="{ name: 'peliculas' }" class="nav-link">Películas</router-link></li>
                    <li class="nav-item"><router-link :to="{ name: 'personas' }" class="nav-link">Personas</router-link></li>
                </ul>
            </div>
        </nav>
        <div id="content" class="container">
            <router-view></router-view>
        </div>
    </div>
</template>

<script>
export default {
    data() {
        return {

        }
    },
    created() {
        
    }
}
</script>
