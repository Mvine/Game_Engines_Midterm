#include "Wrapper.h"
#include "GameObject.h"

GameObject gameObject;

int GetID()
{
	return gameObject.GetID();
}

void SetID(const int id)
{
	gameObject.SetID(id);
}

Vector3D GetPosition()
{
	return gameObject.GetPosition();
}

void SetPosition(const float x, const float y, const float z)
{
	gameObject.SetPosition(x, y, z);
}
