<template>
    <div>
        <div id="menu">
            <router-link :to="{ name: 'dashboard' }">Dashboard</router-link>
            <router-link :to="{ name: 'pagina1' }">Pagina 1</router-link>
            <router-link :to="{ name: 'pagina2' }">Pagina 2</router-link>
        </div>
        <div id="content">
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
