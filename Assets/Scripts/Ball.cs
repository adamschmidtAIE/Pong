using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Ball")]
public class Ball : ScriptableObject {

    public float baseMoveSpeed;
    public float bounceModifier;
    public float gravity;
    public float ballSize;
    public Sprite sprite;
}
