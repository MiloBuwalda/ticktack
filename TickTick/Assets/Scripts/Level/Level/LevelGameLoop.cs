using UnityEngine;
using System.Collections;

partial class Level 
{

  /*  public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);

        TimerGameObject timer = this.Find("timer") as TimerGameObject;
        Player player = this.Find("player") as Player;

        // check if we died
        if (!player.IsAlive)
            timer.Running = false;

        // check if we ran out of time
        if (timer.GameOver)
            player.Explode();

        // check if we won
        if (this.Completed && timer.Running)
        {
            player.LevelFinished();
            timer.Running = false;
        }
    }*/

    public void Reset()
    {
       // base.Reset();
        hint.SetActive(true);
        hint.GetComponent<Hint>().Reset();

        foreach (GameObject drop in waterdrops)
        {
            drop.GetComponent<WaterDrop>().Reset();
        }

        // TODO
        //reset player
        // reset enemies
        // tilefield?
    }
}