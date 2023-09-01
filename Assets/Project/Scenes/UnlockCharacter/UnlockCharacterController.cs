using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SS.View;

public class UnlockCharacterController : Controller
{
    public const string UNLOCKCHARACTER_SCENE_NAME = "UnlockCharacter";

    public override string SceneName()
    {
        return UNLOCKCHARACTER_SCENE_NAME;
    }
}