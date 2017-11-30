﻿using System;
using System.Drawing;
using System.Linq;

using Microsoft.Xna.Framework.Input;

using GielinorAdventures.Input.Enumerations;
using GielinorAdventures.Input.Events;

namespace GielinorAdventures.Input
{
    /// <summary>
    /// Input manager.
    /// </summary>
    public class InputManager
    {
        /// <summary>
        /// Occurs when a mouse button was pressed.
        /// </summary>
        public event MouseButtonEventHandler MouseButtonPressed;

        /// <summary>
        /// Occurs when a mouse button was released.
        /// </summary>
        public event MouseButtonEventHandler MouseButtonReleased;

        /// <summary>
        /// Occurs when a mouse button is down.
        /// </summary>
        public event MouseButtonEventHandler MouseButtonDown;

        /// <summary>
        /// Occurs when the mouse moves.
        /// </summary>
        public event MouseEventHandler MouseMoved;

        /// <summary>
        /// Occurs when a keyboard key was pressed.
        /// </summary>
        public event KeyboardKeyEventHandler KeyboardKeyPressed;

        /// <summary>
        /// Occurs when a keyboard key was released.
        /// </summary>
        public event KeyboardKeyEventHandler KeyboardKeyReleased;

        /// <summary>
        /// Occurs when a keyboard key is down.
        /// </summary>
        public event KeyboardKeyEventHandler KeyboardKeyDown;

        KeyboardState currentKeyState, previousKeyState;
        MouseState currentMouseState, previousMouseState;

        static volatile InputManager instance;
        static object syncRoot = new object();

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>The instance.</value>
        public static InputManager Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new InputManager();
                        }
                    }
                }

                return instance;
            }
        }

        /// <summary>
        /// Updates the content.
        /// </summary>
        public void Update()
        {
            previousKeyState = currentKeyState;
            previousMouseState = currentMouseState;

            currentKeyState = Keyboard.GetState();
            currentMouseState = Mouse.GetState();

            CheckKeyboardKeyPressed();
            CheckKeyboardKeyReleased();
            CheckKeyboardKeyDown();

            CheckMouseButtonPressed();
            CheckMouseButtonReleased();
            CheckMouseButtonDown();
            CheckMouseMoved();
        }

        /// <summary>
        /// Resets the input states.
        /// </summary>
        public void ResetInputStates()
        {
            previousKeyState = currentKeyState;
            previousMouseState = currentMouseState;

            currentKeyState = new KeyboardState();
            currentMouseState = new MouseState();
        }

        public bool IsKeyDown(params Keys[] keys)
        {
            return keys.All(currentKeyState.IsKeyDown);
        }

        public bool IsAnyKeyDown()
        {
            Keys[] allKeys = Enum.GetValues(typeof(Keys)).Cast<Keys>().ToArray();

            return IsAnyKeyDown(allKeys);
        }

        public bool IsAnyKeyDown(params Keys[] keys)
        {
            return keys.Any(currentKeyState.IsKeyDown);
        }

        public bool IsMouseButtonPressed(params MouseButton[] buttons)
        {
            return buttons.All(IsMouseButtonPressed);
        }

        public bool IsAnyMouseButtonPressed()
        {
            MouseButton[] allButtons = Enum.GetValues(typeof(MouseButton)).Cast<MouseButton>().ToArray();

            return IsAnyMouseButtonPressed(allButtons);
        }

        public bool IsAnyMouseButtonPressed(params MouseButton[] buttons)
        {
            return buttons.Any(IsMouseButtonPressed);
        }

        void CheckKeyboardKeyPressed()
        {
            foreach (Keys key in Enum.GetValues(typeof(Keys)))
            {
                if (currentKeyState.IsKeyDown(key) && previousKeyState.IsKeyUp(key))
                {
                    this_OnKeyboardKeyPressed(this, new KeyboardKeyEventArgs(key, KeyboardKeyState.Pressed));
                }
            }
        }

        void CheckKeyboardKeyReleased()
        {
            foreach (Keys key in Enum.GetValues(typeof(Keys)))
            {
                if (currentKeyState.IsKeyUp(key) && previousKeyState.IsKeyDown(key))
                {
                    this_OnKeyboardKeyReleased(this, new KeyboardKeyEventArgs(key, KeyboardKeyState.Released));
                }
            }
        }

        void CheckKeyboardKeyDown()
        {
            foreach (Keys key in Enum.GetValues(typeof(Keys)))
            {
                if (currentKeyState.IsKeyDown(key))
                {
                    this_OnKeyboardKeyDown(this, new KeyboardKeyEventArgs(key, KeyboardKeyState.Down));
                }
            }
        }

        void CheckMouseButtonPressed()
        {
            if (currentMouseState.LeftButton == ButtonState.Pressed &&
                previousMouseState.LeftButton != ButtonState.Pressed)
            {
                this_OnMouseButtonPressed(this, new MouseButtonEventArgs(MouseButton.LeftButton,
                                                                         MouseButtonState.Pressed,
                                                                         new Point(currentMouseState.Position.X,
                                                                                   currentMouseState.Position.Y)));
            }

            if (currentMouseState.RightButton == ButtonState.Pressed &&
                previousMouseState.RightButton != ButtonState.Pressed)
            {
                this_OnMouseButtonPressed(this, new MouseButtonEventArgs(MouseButton.RightButton,
                                                                         MouseButtonState.Pressed,
                                                                         new Point(currentMouseState.Position.X,
                                                                                   currentMouseState.Position.Y)));
            }

            if (currentMouseState.MiddleButton == ButtonState.Pressed &&
                previousMouseState.MiddleButton != ButtonState.Pressed)
            {
                this_OnMouseButtonPressed(this, new MouseButtonEventArgs(MouseButton.MiddleButton,
                                                                         MouseButtonState.Pressed,
                                                                         new Point(currentMouseState.Position.X,
                                                                                   currentMouseState.Position.Y)));
            }
        }

        void CheckMouseButtonReleased()
        {
            if (currentMouseState.LeftButton == ButtonState.Released &&
                previousMouseState.LeftButton != ButtonState.Released)
            {
                this_OnMouseButtonReleased(this, new MouseButtonEventArgs(MouseButton.LeftButton,
                                                                          MouseButtonState.Released,
                                                                          new Point(currentMouseState.Position.X,
                                                                                    currentMouseState.Position.Y)));
            }

            if (currentMouseState.RightButton == ButtonState.Released &&
                previousMouseState.RightButton != ButtonState.Released)
            {
                this_OnMouseButtonReleased(this, new MouseButtonEventArgs(MouseButton.RightButton,
                                                                          MouseButtonState.Released,
                                                                          new Point(currentMouseState.Position.X,
                                                                                    currentMouseState.Position.Y)));
            }

            if (currentMouseState.MiddleButton == ButtonState.Released &&
                previousMouseState.MiddleButton != ButtonState.Released)
            {
                this_OnMouseButtonReleased(this, new MouseButtonEventArgs(MouseButton.MiddleButton,
                                                                          MouseButtonState.Released,
                                                                          new Point(currentMouseState.Position.X,
                                                                                    currentMouseState.Position.Y)));
            }
        }

        void CheckMouseButtonDown()
        {
            if (currentMouseState.LeftButton == ButtonState.Pressed)
            {
                this_OnMouseButtonDown(this, new MouseButtonEventArgs(MouseButton.LeftButton,
                                                                      MouseButtonState.Down,
                                                                      new Point(currentMouseState.Position.X,
                                                                                currentMouseState.Position.Y)));
            }

            if (currentMouseState.RightButton == ButtonState.Pressed)
            {
                this_OnMouseButtonDown(this, new MouseButtonEventArgs(MouseButton.RightButton,
                                                                      MouseButtonState.Down,
                                                                      new Point(currentMouseState.Position.X,
                                                                                currentMouseState.Position.Y)));
            }

            if (currentMouseState.MiddleButton == ButtonState.Pressed)
            {
                this_OnMouseButtonDown(this, new MouseButtonEventArgs(MouseButton.MiddleButton,
                                                                      MouseButtonState.Down,
                                                                      new Point(currentMouseState.Position.X,
                                                                                currentMouseState.Position.Y)));
            }
        }

        void CheckMouseMoved()
        {
            if (currentMouseState.Position != previousMouseState.Position)
            {
                this_OnMouseMoved(this, new MouseEventArgs(new Point(currentMouseState.Position.X, currentMouseState.Position.Y),
                                                           new Point(previousMouseState.Position.X, previousMouseState.Position.Y)));
            }
        }

        bool IsMouseButtonPressed(MouseButton button)
        {
            switch (button)
            {
                case MouseButton.LeftButton:
                    return currentMouseState.LeftButton == ButtonState.Pressed &&
                           previousMouseState.LeftButton == ButtonState.Released;

                case MouseButton.RightButton:
                    return currentMouseState.RightButton == ButtonState.Pressed &&
                           previousMouseState.LeftButton == ButtonState.Released;

                case MouseButton.MiddleButton:
                    return currentMouseState.MiddleButton == ButtonState.Pressed &&
                           previousMouseState.LeftButton == ButtonState.Released;

                default:
                    return false;
            }
        }

        /// <summary>
        /// Fires when a keyboard key was pressed.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        void this_OnKeyboardKeyPressed(object sender, KeyboardKeyEventArgs e)
        {
            if (KeyboardKeyPressed != null)
            {
                KeyboardKeyPressed(sender, e);
            }
        }

        /// <summary>
        /// Fires when a keyboard key was released.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        void this_OnKeyboardKeyReleased(object sender, KeyboardKeyEventArgs e)
        {
            if (KeyboardKeyReleased != null)
            {
                KeyboardKeyReleased(sender, e);
            }
        }

        /// <summary>
        /// Fires when a keyboard key is down.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        void this_OnKeyboardKeyDown(object sender, KeyboardKeyEventArgs e)
        {
            if (KeyboardKeyDown != null)
            {
                KeyboardKeyDown(sender, e);
            }
        }

        /// <summary>
        /// Fires when a mouse button was pressed.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        void this_OnMouseButtonPressed(object sender, MouseButtonEventArgs e)
        {
            if (MouseButtonPressed != null)
            {
                MouseButtonPressed(sender, e);
            }
        }

        /// <summary>
        /// Fires when a mouse button was released.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        void this_OnMouseButtonReleased(object sender, MouseButtonEventArgs e)
        {
            if (MouseButtonReleased != null)
            {
                MouseButtonReleased(sender, e);
            }
        }

        /// <summary>
        /// Fires when a mouse button is down.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        void this_OnMouseButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (MouseButtonDown != null)
            {
                MouseButtonDown(sender, e);
            }
        }

        /// <summary>
        /// Fires when the mouse was moved.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        void this_OnMouseMoved(object sender, MouseEventArgs e)
        {
            if (MouseMoved != null)
            {
                MouseMoved(sender, e);
            }
        }

        // TODO: Everything below this is required by a workaround to a problem and should be removed as soon as it is properly fixed

        public Point MouseLocation => new Point(currentMouseState.Position.X, currentMouseState.Position.Y);
        public bool MouseButtonInputHandled { get; set; }

        public bool IsLeftMouseButtonClicked()
        {
            if (currentMouseState.LeftButton == ButtonState.Pressed &&
                previousMouseState.LeftButton == ButtonState.Released)
            {
                return true;
            }

            return false;
        }
    }
}
