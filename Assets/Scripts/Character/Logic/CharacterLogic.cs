using Character.Presentation;
using UnityEngine;

namespace Character.Logic
{
    public class CharacterLogic
    {
        private Vector3 currentPosition;
        private Vector3 targetPosition;
        private Vector3 startingPosition;
        
        private float currentRotation;
        private float targetRotation;
        private float startingRotation;


        private CharacterPresentation characterPresentation;

        public CharacterLogic(Vector3 startingPosition, float startingRotation)
        {
            this.startingPosition = startingPosition;
            this.startingRotation = startingRotation;

            currentPosition = startingPosition;
            currentRotation = startingRotation;
            
            characterPresentation = new CharacterPresentation();
        }

        private void Walk()
        {
            characterPresentation.Walk(targetPosition); //how do we have target position? cant presentation just keep track of this?
            //what is the point of these? also walk is IEnumerator 
        }

        private void Light()
        {
            characterPresentation.Light();
        }

        private void TurnLeft()
        {
            characterPresentation.Turn(-90f); 
        }

        private void TurnRight()
        {
            characterPresentation.Turn(90f); 
        }
        
        private void Jump()
        {
            characterPresentation.Jump();
        }

    }
}
