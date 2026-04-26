window.exploreCanvas = {
    tile: null,
    playerImg: null,
    enemyImg: null,
    exitImg: null,
    waterImg: null,
    ready: false,


    init: function () {
        if (this.ready) return;

        //cave tile
        this.tile = new Image();
        this.tile.src = 'images/tile3.png';

        //player sprite
        this.playerImg = new Image();
        this.playerImg.src = 'images/warrior.png';

        //enemy sprite
        this.enemyImg = new Image();
        this.enemyImg.src = 'images/goblin.png';

        //exit tile sprite
        this.exitImg = new Image();
        this.exitImg.src = 'images/tower.png';

        //water tile img
        this.waterImg = new Image();
        this.waterImg.src = 'images/bush.png'

        this.ready = true;
    },

    drawScene: function (playerX, playerY, enemies, waters, exit, width, height) {
        const canvas = document.getElementById('exploreCanvas');
        if (!canvas) return;
        const ctx = canvas.getContext('2d');
        
        const cellW = canvas.width / width;
        const cellH = canvas.height / height;

        const draw = () => {
            ctx.clearRect(0, 0, canvas.width, canvas.height);

            //draw cave tiles
            for (let x = 0; x < width; x++) {
                for (let y = 0; y < height; y++) {

                    ctx.drawImage(this.tile, x * cellW, y * cellH, cellW, cellH);
                }
            }

            //draw water tiles
            if (waters && waters.length > 0) {
                waters.forEach(w => {
                    const wx = w.X ?? w.x;
                    const wy = w.Y ?? w.y;
                    if (this.waterImg.complete) {
                        ctx.drawImage(this.waterImg, wx * cellW, wy * cellH, cellW, cellH);
                    } else {
                        this.waterImg.onload = () => ctx.drawImage(this.waterImg, wx * cellW, wy * cellH, cellW, cellH);
                    }
                });
            }

            //draw exit image
            if (exit) {
                const exitX = exit.X ?? exit.x;
                const exitY = exit.Y ?? exit.y;
                ctx.drawImage(this.exitImg, exitX * cellW, exitY * cellH, cellW, cellH);
            }

            //draw enemies images
            if (enemies && enemies.length > 0) {
                enemies.forEach(e => {
                    const ex = e.X ?? e.x;
                    const ey = e.Y ?? e.y;
                    if (this.enemyImg.complete) {
                        ctx.drawImage(this.enemyImg, ex * cellW, ey * cellH, cellW, cellH);
                    } else {
                        this.enemyImg.onload = () => ctx.drawImage(this.enemyImg, ex * cellW, ey * cellH, cellW, cellH);
                    }
                });
            }

            //draw player image
            if (this.playerImg.complete) {
                ctx.drawImage(this.playerImg, playerX * cellW, playerY * cellH, cellW, cellH);
            } else {
                this.playerImg.onload = () => ctx.drawImage(this.playerImg, playerX * cellW, playerY * cellH, cellW, cellH);
            }
        };

        //qait until tile image is loaded
        if (this.tile.complete) {
            draw();
        } else {
            this.tile.onload = draw;
        }
    }
};

window.exploreControls = {
    init: function (dotNetObjRef) {
        //listen for keydown events
        window.addEventListener('keydown', function (e) {
            if (window.inCombat) return;

            let dx = 0, dy = 0;
            
            switch (e.key.toLowerCase()) {
                case 'w':
                case 'arrowup':
                    dy = -1;
                    break;
                case 'a':
                case 'arrowleft':
                    dx = -1;
                    break;
                case 's':
                case 'arrowdown':
                    dy = 1;
                    break;
                case 'd':
                case 'arrowright':
                    dx = 1;
                    break;
                default:
                    return; //ignore other keys
            }

            //calls move method with the dotnet object reference
            dotNetObjRef.invokeMethodAsync('Move', dx, dy);
        });
    }
};