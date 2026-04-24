window.combatCanvas = {
    playerImg: null,
    enemyImg: null,
    init: function () {
        if (!this.playerImg) {
            this.playerImg = new Image();
            this.playerImg.src = 'images/wizard.png'; //player sprite
        }
        if (!this.enemyImg) {
            this.enemyImg = new Image();
            this.enemyImg.src = 'images/goblin.png'; //enemy sprite
        }
    },

    drawCombat: function () {
        const canvas = document.getElementById('combatCanvas');
        if (!canvas) return;
        const ctx = canvas.getContext('2d');
        ctx.clearRect(0, 0, canvas.width, canvas.height);

        //draw player on left
        if (this.playerImg.complete)
            ctx.drawImage(this.playerImg, 50, 100, 80, 80);

        //draw enemy on right
        if (this.enemyImg.complete)
            ctx.drawImage(this.enemyImg, 270, 100, 80, 80);
    },

    attackAnimation: function () {
        const canvas = document.getElementById('combatCanvas');
        if (!canvas) return;
        const ctx = canvas.getContext('2d');

        //draw flash on enemy
        const flash = () => {
            //save the current canvas
            ctx.save();

            //draw yellow flash over enemy
            ctx.fillStyle = 'rgba(255,255,0,0.5)';
            ctx.fillRect(270, 100, 80, 80);

            //after 200ms restore combat canvas
            setTimeout(() => {
                this.drawCombat(); //redraw player/enemy images
                ctx.restore();
            }, 200);
        };

        //check if images are loaded before flashing
        if (this.playerImg.complete && this.enemyImg.complete) {
            requestAnimationFrame(flash);
        } else {
            this.playerImg.onload = this.enemyImg.onload = () => requestAnimationFrame(flash);
        }
    }
};