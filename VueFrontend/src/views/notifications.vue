
<template>
    <div id="notifications">
        <div v-for="notification in notifications" :class="getNotificationClass(notification)" v-bind:key="notification.message">
            {{ notification.message }}
        </div>
    </div>
</template>

<script>
    export default{
        data(){
            return{
            }
        },
        methods: {
            getNotificationClass: function(notification)
            {
                return 'alert alert-' + notification.type;
            }
        },
        props: ['notifications']
    }
</script>