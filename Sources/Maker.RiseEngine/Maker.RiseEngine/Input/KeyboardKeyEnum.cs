using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maker.RiseEngine.Input
{
    //
    // Résumé :
    //     The available keyboard keys.
    public enum KeyboardKey
    {
        //
        // Résumé :
        //     A key outside the known keys.
        Unknown = 0,
        //
        // Résumé :
        //     The left shift key.
        ShiftLeft = 1,
        //
        // Résumé :
        //     The left shift key (equivalent to ShiftLeft).
        LShift = 1,
        //
        // Résumé :
        //     The right shift key.
        ShiftRight = 2,
        //
        // Résumé :
        //     The right shift key (equivalent to ShiftRight).
        RShift = 2,
        //
        // Résumé :
        //     The left control key.
        ControlLeft = 3,
        //
        // Résumé :
        //     The left control key (equivalent to ControlLeft).
        LControl = 3,
        //
        // Résumé :
        //     The right control key.
        ControlRight = 4,
        //
        // Résumé :
        //     The right control key (equivalent to ControlRight).
        RControl = 4,
        //
        // Résumé :
        //     The left alt key.
        AltLeft = 5,
        //
        // Résumé :
        //     The left alt key (equivalent to AltLeft.
        LAlt = 5,
        //
        // Résumé :
        //     The right alt key.
        AltRight = 6,
        //
        // Résumé :
        //     The right alt key (equivalent to AltRight).
        RAlt = 6,
        //
        // Résumé :
        //     The left win key.
        WinLeft = 7,
        //
        // Résumé :
        //     The left win key (equivalent to WinLeft).
        LWin = 7,
        //
        // Résumé :
        //     The right win key.
        WinRight = 8,
        //
        // Résumé :
        //     The right win key (equivalent to WinRight).
        RWin = 8,
        //
        // Résumé :
        //     The menu key.
        Menu = 9,
        //
        // Résumé :
        //     The F1 key.
        F1 = 10,
        //
        // Résumé :
        //     The F2 key.
        F2 = 11,
        //
        // Résumé :
        //     The F3 key.
        F3 = 12,
        //
        // Résumé :
        //     The F4 key.
        F4 = 13,
        //
        // Résumé :
        //     The F5 key.
        F5 = 14,
        //
        // Résumé :
        //     The F6 key.
        F6 = 15,
        //
        // Résumé :
        //     The F7 key.
        F7 = 16,
        //
        // Résumé :
        //     The F8 key.
        F8 = 17,
        //
        // Résumé :
        //     The F9 key.
        F9 = 18,
        //
        // Résumé :
        //     The F10 key.
        F10 = 19,
        //
        // Résumé :
        //     The F11 key.
        F11 = 20,
        //
        // Résumé :
        //     The F12 key.
        F12 = 21,
        //
        // Résumé :
        //     The F13 key.
        F13 = 22,
        //
        // Résumé :
        //     The F14 key.
        F14 = 23,
        //
        // Résumé :
        //     The F15 key.
        F15 = 24,
        //
        // Résumé :
        //     The F16 key.
        F16 = 25,
        //
        // Résumé :
        //     The F17 key.
        F17 = 26,
        //
        // Résumé :
        //     The F18 key.
        F18 = 27,
        //
        // Résumé :
        //     The F19 key.
        F19 = 28,
        //
        // Résumé :
        //     The F20 key.
        F20 = 29,
        //
        // Résumé :
        //     The F21 key.
        F21 = 30,
        //
        // Résumé :
        //     The F22 key.
        F22 = 31,
        //
        // Résumé :
        //     The F23 key.
        F23 = 32,
        //
        // Résumé :
        //     The F24 key.
        F24 = 33,
        //
        // Résumé :
        //     The F25 key.
        F25 = 34,
        //
        // Résumé :
        //     The F26 key.
        F26 = 35,
        //
        // Résumé :
        //     The F27 key.
        F27 = 36,
        //
        // Résumé :
        //     The F28 key.
        F28 = 37,
        //
        // Résumé :
        //     The F29 key.
        F29 = 38,
        //
        // Résumé :
        //     The F30 key.
        F30 = 39,
        //
        // Résumé :
        //     The F31 key.
        F31 = 40,
        //
        // Résumé :
        //     The F32 key.
        F32 = 41,
        //
        // Résumé :
        //     The F33 key.
        F33 = 42,
        //
        // Résumé :
        //     The F34 key.
        F34 = 43,
        //
        // Résumé :
        //     The F35 key.
        F35 = 44,
        //
        // Résumé :
        //     The up arrow key.
        Up = 45,
        //
        // Résumé :
        //     The down arrow key.
        Down = 46,
        //
        // Résumé :
        //     The left arrow key.
        Left = 47,
        //
        // Résumé :
        //     The right arrow key.
        Right = 48,
        //
        // Résumé :
        //     The enter key.
        Enter = 49,
        //
        // Résumé :
        //     The escape key.
        Escape = 50,
        //
        // Résumé :
        //     The space key.
        Space = 51,
        //
        // Résumé :
        //     The tab key.
        Tab = 52,
        //
        // Résumé :
        //     The backspace key.
        BackSpace = 53,
        //
        // Résumé :
        //     The backspace key (equivalent to BackSpace).
        Back = 53,
        //
        // Résumé :
        //     The insert key.
        Insert = 54,
        //
        // Résumé :
        //     The delete key.
        Delete = 55,
        //
        // Résumé :
        //     The page up key.
        PageUp = 56,
        //
        // Résumé :
        //     The page down key.
        PageDown = 57,
        //
        // Résumé :
        //     The home key.
        Home = 58,
        //
        // Résumé :
        //     The end key.
        End = 59,
        //
        // Résumé :
        //     The caps lock key.
        CapsLock = 60,
        //
        // Résumé :
        //     The scroll lock key.
        ScrollLock = 61,
        //
        // Résumé :
        //     The print screen key.
        PrintScreen = 62,
        //
        // Résumé :
        //     The pause key.
        Pause = 63,
        //
        // Résumé :
        //     The num lock key.
        NumLock = 64,
        //
        // Résumé :
        //     The clear key (Keypad5 with NumLock disabled, on typical keyboards).
        Clear = 65,
        //
        // Résumé :
        //     The sleep key.
        Sleep = 66,
        //
        // Résumé :
        //     The keypad 0 key.
        Keypad0 = 67,
        //
        // Résumé :
        //     The keypad 1 key.
        Keypad1 = 68,
        //
        // Résumé :
        //     The keypad 2 key.
        Keypad2 = 69,
        //
        // Résumé :
        //     The keypad 3 key.
        Keypad3 = 70,
        //
        // Résumé :
        //     The keypad 4 key.
        Keypad4 = 71,
        //
        // Résumé :
        //     The keypad 5 key.
        Keypad5 = 72,
        //
        // Résumé :
        //     The keypad 6 key.
        Keypad6 = 73,
        //
        // Résumé :
        //     The keypad 7 key.
        Keypad7 = 74,
        //
        // Résumé :
        //     The keypad 8 key.
        Keypad8 = 75,
        //
        // Résumé :
        //     The keypad 9 key.
        Keypad9 = 76,
        //
        // Résumé :
        //     The keypad divide key.
        KeypadDivide = 77,
        //
        // Résumé :
        //     The keypad multiply key.
        KeypadMultiply = 78,
        //
        // Résumé :
        //     The keypad subtract key.
        KeypadSubtract = 79,
        //
        // Résumé :
        //     The keypad minus key (equivalent to KeypadSubtract).
        KeypadMinus = 79,
        //
        // Résumé :
        //     The keypad add key.
        KeypadAdd = 80,
        //
        // Résumé :
        //     The keypad plus key (equivalent to KeypadAdd).
        KeypadPlus = 80,
        //
        // Résumé :
        //     The keypad decimal key.
        KeypadDecimal = 81,
        //
        // Résumé :
        //     The keypad period key (equivalent to KeypadDecimal).
        KeypadPeriod = 81,
        //
        // Résumé :
        //     The keypad enter key.
        KeypadEnter = 82,
        //
        // Résumé :
        //     The A key.
        A = 83,
        //
        // Résumé :
        //     The B key.
        B = 84,
        //
        // Résumé :
        //     The C key.
        C = 85,
        //
        // Résumé :
        //     The D key.
        D = 86,
        //
        // Résumé :
        //     The E key.
        E = 87,
        //
        // Résumé :
        //     The F key.
        F = 88,
        //
        // Résumé :
        //     The G key.
        G = 89,
        //
        // Résumé :
        //     The H key.
        H = 90,
        //
        // Résumé :
        //     The I key.
        I = 91,
        //
        // Résumé :
        //     The J key.
        J = 92,
        //
        // Résumé :
        //     The K key.
        K = 93,
        //
        // Résumé :
        //     The L key.
        L = 94,
        //
        // Résumé :
        //     The M key.
        M = 95,
        //
        // Résumé :
        //     The N key.
        N = 96,
        //
        // Résumé :
        //     The O key.
        O = 97,
        //
        // Résumé :
        //     The P key.
        P = 98,
        //
        // Résumé :
        //     The Q key.
        Q = 99,
        //
        // Résumé :
        //     The R key.
        R = 100,
        //
        // Résumé :
        //     The S key.
        S = 101,
        //
        // Résumé :
        //     The T key.
        T = 102,
        //
        // Résumé :
        //     The U key.
        U = 103,
        //
        // Résumé :
        //     The V key.
        V = 104,
        //
        // Résumé :
        //     The W key.
        W = 105,
        //
        // Résumé :
        //     The X key.
        X = 106,
        //
        // Résumé :
        //     The Y key.
        Y = 107,
        //
        // Résumé :
        //     The Z key.
        Z = 108,
        //
        // Résumé :
        //     The number 0 key.
        Number0 = 109,
        //
        // Résumé :
        //     The number 1 key.
        Number1 = 110,
        //
        // Résumé :
        //     The number 2 key.
        Number2 = 111,
        //
        // Résumé :
        //     The number 3 key.
        Number3 = 112,
        //
        // Résumé :
        //     The number 4 key.
        Number4 = 113,
        //
        // Résumé :
        //     The number 5 key.
        Number5 = 114,
        //
        // Résumé :
        //     The number 6 key.
        Number6 = 115,
        //
        // Résumé :
        //     The number 7 key.
        Number7 = 116,
        //
        // Résumé :
        //     The number 8 key.
        Number8 = 117,
        //
        // Résumé :
        //     The number 9 key.
        Number9 = 118,
        //
        // Résumé :
        //     The tilde key.
        Tilde = 119,
        //
        // Résumé :
        //     The grave key (equivaent to Tilde).
        Grave = 119,
        //
        // Résumé :
        //     The minus key.
        Minus = 120,
        //
        // Résumé :
        //     The plus key.
        Plus = 121,
        //
        // Résumé :
        //     The left bracket key.
        BracketLeft = 122,
        //
        // Résumé :
        //     The left bracket key (equivalent to BracketLeft).
        LBracket = 122,
        //
        // Résumé :
        //     The right bracket key.
        BracketRight = 123,
        //
        // Résumé :
        //     The right bracket key (equivalent to BracketRight).
        RBracket = 123,
        //
        // Résumé :
        //     The semicolon key.
        Semicolon = 124,
        //
        // Résumé :
        //     The quote key.
        Quote = 125,
        //
        // Résumé :
        //     The comma key.
        Comma = 126,
        //
        // Résumé :
        //     The period key.
        Period = 127,
        //
        // Résumé :
        //     The slash key.
        Slash = 128,
        //
        // Résumé :
        //     The backslash key.
        BackSlash = 129,
        //
        // Résumé :
        //     The secondary backslash key.
        NonUSBackSlash = 130,
        //
        // Résumé :
        //     Indicates the last available keyboard key.
        LastKey = 131
    }
}
