window.combatCanvas = {
    playerImg: null,
    enemyImg: null,
    backImg: null,
    attackImg: null,

    state: {
        playerOffsetX: 0,
        enemyOffsetX: 0,
        flash: 0,
        shake: 0
    },

    attackAnim: {
        active: false,
        timer: 0,
        x: 200,
    },
    lastTime: 0,
    running: false,

    init: function () {
        if (!this.playerImg) {
            this.playerImg = new Image();
            this.playerImg.src = 'images/warrior.png'; //player sprite
        }
        if (!this.enemyImg) {
            this.enemyImg = new Image();
            this.enemyImg.src = 'images/goblin.png'; //enemy sprite
        }
        if (!this.backImg) {
            this.backImg = new Image();
            this.backImg.src = 'images/caveback.jpg';//background img
        }

        if (!this.attackImg) {
            this.attackImg = new Image();
            this.attackImg.src = 'images/attack.png';
        }

        if (!this.running) {
            this.running = true;
            this.lastTime = performance.now();
            requestAnimationFrame(this.loop.bind(this));
        }
    },

    updateEnemyImage: function (iconPath) {
        this.enemyImg = new Image();
        this.enemyImg.src = iconPath;  //update enemy img
    },

    loop: function (time) {
        const dt = (time - this.lastTime) / 1000;
        this.lastTime = time;
        this.update(dt);
        this.drawCombat();

        requestAnimationFrame(this.loop.bind(this));

    },

    update: function (dt) {
        const s = this.state;
        const a = this.attackAnim;

        s.shake *= 0.9;
        s.flash *= 0.85;
        s.playerOffsetX *= 0.8;
        s.enemyOffsetX *= 0.8;

        //attack animation frames
        if (a.active) {
            a.timer += dt * 1.8; //speed

            const t = a.timer;

            const startX = 200;
            const hitX = 650;

            //forward
            if (t < 1) {
                const p = t;

                const ease = 1 - Math.pow(1 - p, 3); //smooth forward
                a.x = startX + (hitX - startX) * ease;


                if (t >= 0.5 && a.timer - dt < 0.5) {
                   // s.flash = 0.8;
                    s.shake = 15;
                }
            }



            //return
            else if (t < 2) {
                const p = t - 1;

                const ease = Math.pow(p, 3); //smooth return
                a.x = hitX - (hitX - startX) * ease;
            }

            //end
            else {
                a.active = false;
                a.timer = 0;
                a.x = startX;
            }
        }
    },


    drawCombat: function (enemyIcon) {
        const canvas = document.getElementById('combatCanvas');
        if (!canvas) return;
        const ctx = canvas.getContext('2d');

        const s = this.state;
        const a = this.attackAnim;
        const shakeX = (Math.random() - 0.5) * s.shake;
        const shakeY = (Math.random() - 0.5) * s.shake;

        ctx.save();
        ctx.translate(shakeX, shakeY);


        if (enemyIcon) {
            if (!this.enemyImg || this.enemyImg.src !== enemyIcon) {
                this.enemyImg = new Image();
                this.enemyImg.src = enemyIcon;
            }
        }

        //draw background
        if (this.backImg.complete) {
            ctx.drawImage(this.backImg, 0, 0, canvas.width, canvas.height);
        }
        //draw idle player on left
        if (this.playerImg.complete && !a.active)
            ctx.drawImage(this.playerImg, 200 , 400, 240, 240);

        //draw attack animation
        if (this.attackImg && this.attackImg.complete && a.active) {

            const frameW = this.attackImg.width / 4;
            const frameH = this.attackImg.height;

            ctx.drawImage(this.attackImg, Math.floor((a.timer * 10) % 4) * frameW, 0, frameW, frameH, a.x, 380, 320, 320);

        }

        //draw enemy on right
        if (this.enemyImg.complete)
            ctx.drawImage(this.enemyImg, 800 + s.enemyOffsetX, 400, 160, 160);

        //flash effect
        if (s.flash > 0.05) {
            ctx.fillStyle = `rgba(255, 0, 0, ${s.flash})`;
            ctx.fillRect(0, 0, canvas.width, canvas.height);
        }

        ctx.restore();

    },

    attackAnimation: function () {
        const s = this.state;
        const a = this.attackAnim;
        //start animation
        a.active = true;
        a.timer = 0;
        a.x = 200;

        //impact
    

    },

    eAttackAnimation: function () {
        const s = this.state;
        let t = 0;
        setTimeout(() => {
            const anim = setInterval(() => {

                t += 0.05;
                s.enemyOffsetX = -200 * Math.sin(t * Math.PI);

                if (t >= 1) {
                    s.enemyOffsetX = 0;
                    clearInterval(anim);
                }

            }, 16);
            setTimeout(() => {
                s.flash = 0.6;
                s.shake = 10;
            }, 120);
        }, 1200);
        
        
    }
};