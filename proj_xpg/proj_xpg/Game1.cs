using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace proj_xpg
{
    /// <summary>
    /// Dies ist der Haupttyp für Ihr Spiel
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Texture2D tempMap;
        SpriteFont tempFont;
        float tempFloat = 1;

        Camera camera;
        GamePadState lastGamePadState;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 720;

        }

        /// <summary>
        /// Ermöglicht dem Spiel, alle Initialisierungen durchzuführen, die es benötigt, bevor die Ausführung gestartet wird.
        /// Hier können erforderliche Dienste abgefragt und alle nicht mit Grafiken
        /// verbundenen Inhalte geladen werden.  Bei Aufruf von base.Initialize werden alle Komponenten aufgezählt
        /// sowie initialisiert.
        /// </summary>
        protected override void Initialize()
        {
            camera = new Camera();

            base.Initialize();
        }

        /// <summary>
        /// LoadContent wird einmal pro Spiel aufgerufen und ist der Platz, wo
        /// Ihr gesamter Content geladen wird.
        /// </summary>
        protected override void LoadContent()
        {
            // Erstellen Sie einen neuen SpriteBatch, der zum Zeichnen von Texturen verwendet werden kann.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            tempFont = Content.Load<SpriteFont>("textbox");
            tempMap = Content.Load<Texture2D>("full map scale");
            camera = new Camera(Convert.ToInt32(tempMap.Width), Convert.ToInt32(tempMap.Height));

            // TODO: Verwenden Sie this.Content, um Ihren Spiel-Inhalt hier zu laden
        }

        /// <summary>
        /// UnloadContent wird einmal pro Spiel aufgerufen und ist der Ort, wo
        /// Ihr gesamter Content entladen wird.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Entladen Sie jeglichen Nicht-ContentManager-Inhalt hier
        }

        /// <summary>
        /// Ermöglicht dem Spiel die Ausführung der Logik, wie zum Beispiel Aktualisierung der Welt,
        /// Überprüfung auf Kollisionen, Erfassung von Eingaben und Abspielen von Ton.
        /// </summary>
        /// <param name="gameTime">Bietet einen Schnappschuss der Timing-Werte.</param>
        protected override void Update(GameTime gameTime)
        {
            // Ermöglicht ein Beenden des Spiels
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            if (GamePad.GetState(PlayerIndex.One).Buttons.Start == ButtonState.Pressed && lastGamePadState.Buttons.Start == ButtonState.Released)
            {
                graphics.IsFullScreen = !graphics.IsFullScreen;
                graphics.ApplyChanges();
            }

            if (GamePad.GetState(PlayerIndex.One).DPad.Left == ButtonState.Pressed && lastGamePadState.DPad.Left == ButtonState.Released)
                tempFloat -= 0.05f;
            if (GamePad.GetState(PlayerIndex.One).DPad.Right == ButtonState.Pressed && lastGamePadState.DPad.Right == ButtonState.Released)
                tempFloat += 0.05f;
            Vector2 cp = new Vector2(GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.X, -GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.Y) * gameTime.ElapsedGameTime.Milliseconds;
            camera.SetPosition(cp + camera.Position, false);

            lastGamePadState = GamePad.GetState(PlayerIndex.One);
            base.Update(gameTime);
        }

        /// <summary>
        /// Dies wird aufgerufen, wenn das Spiel selbst zeichnen soll.
        /// </summary>
        /// <param name="gameTime">Bietet einen Schnappschuss der Timing-Werte.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null, camera.Matrix * Matrix.CreateScale(tempFloat));
            spriteBatch.Draw(tempMap, new Vector2(0, 0), Color.White);
            spriteBatch.End();

            spriteBatch.Begin();
            spriteBatch.DrawString(tempFont, (Convert.ToInt16(tempFloat * 100)).ToString() + "%\n" + (Convert.ToInt16(tempFloat * 80)).ToString() + " Pixel²\n" + (1280 / (tempFloat * 80)).ToString("F3") + "x" + (720 / (tempFloat * 80)).ToString("F3") + " Kacheln", new Vector2(20, 20), Color.Red);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
