using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraFollow : MonoBehaviour
{
public float interpVelocity;
public float minDistance;
public float followDistance;
public GameObject target;
public Vector3 offset;
public float maxY;
public float maxX;
public float minX;
Vector3 targetPos;
void Start()
{
targetPos = transform.position;
print(targetPos.y);
}
void FixedUpdate()
{
if (target)
{
Vector3 posNoZ = transform.position;
posNoZ.z = target.transform.position.z;
//print(posNoZ);
Vector3 targetDirection = (target.transform.position - posNoZ);
interpVelocity = targetDirection.magnitude * 5f;
targetPos = transform.position + (targetDirection.normalized * interpVelocity *
Time.deltaTime);
// Menggunakan Mathf.Clamp untuk membatasi nilai Y dan X
targetPos.y = Mathf.Clamp(targetPos.y, -maxY, maxY);
targetPos.x = Mathf.Clamp(targetPos.x, minX, maxX);
transform.position = Vector3.Lerp(transform.position, targetPos + offset,
0.25f);
}
}
}
