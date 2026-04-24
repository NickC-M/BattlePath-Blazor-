window.combatCanvas = {
    playerImg: null,
    enemyImg: null,
    backImg: null,
    init: function () {
        if (!this.playerImg) {
            this.playerImg = new Image();
            this.playerImg.src = 'images/wizard.png'; //player sprite
        }
        if (!this.enemyImg) {
            this.enemyImg = new Image();
            this.enemyImg.src = 'images/goblin.png'; //enemy sprite
        }
        if (!this.backImg) {
            this.backImg = new Image();
            this.backImg.src = 'images/caveback.jpg';//background img
        }
    },

    drawCombat: function () {
        const canvas = document.getElementById('combatCanvas');
        if (!canvas) return;
        const ctx = canvas.getContext('2d');

        if (this.backImg.complete) {
            ctx.drawImage(this.backImg, 0, 0, canvas.width, canvas.height);
        }
        //draw player on left
        if (this.playerImg.complete)
            ctx.drawImage(this.playerImg, 200, 400, 240, 240);

        //draw enemy on right
        if (this.enemyImg.complete)
            ctx.drawImage(this.enemyImg, 700, 400, 160, 160);

    },

    attackAnimation: function () {
        const canvas = document.getElementById('combatCanvas');
        if (!canvas) return;
        const ctx = canvas.getContext('2d');

        //draw flash on enemy
        const flash = () => {
            //save the current canvas
            ctx.save();

            //draw red flash over enemy
            ctx.fillStyle = 'rgba(255, 0, 0, 0.5)';
            ctx.fillRect(700, 400, 160, 160);

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
    },

    eAttackAnimation: function () {
        const canvas = document.getElementById('combatCanvas');
        if (!canvas) return;
        const ctx = canvas.getContext('2d');

        //draw flash on player
        const flash = () => {
            //save the current canvas
            ctx.save();

            //draw red flash over player
            ctx.fillStyle = 'rgba(255, 0, 0, 0.5)';
            ctx.fillRect(200, 400, 240, 240);

            //after 200ms restore combat canvas
            setTimeout(() => {
                this.drawCombat(); //redraw player/enemy images
                ctx.restore();
            }, 200);
        };

        //check if images are loaded before flashing
        setTimeout(() => {
            if (this.playerImg.complete && this.enemyImg.complete) {
                requestAnimationFrame(flash);
            } else {
                this.playerImg.onload = this.enemyImg.onload = () => requestAnimationFrame(flash);
            }
        }, 500);

    }
};