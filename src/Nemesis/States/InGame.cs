using System;
using System.Collections.Generic;
using System.IO;

using Mogre;

using Nemesis.Modules;

namespace Nemesis.States
{
  /************************************************************************/
  /* program state that just shows a turning ogre head                    */
  /************************************************************************/
  public class InGame : State
  {
    //////////////////////////////////////////////////////////////////////////
    private OgreManager mEngine;

    private List<SceneNode> mMapTiles = new List<SceneNode>();

    /************************************************************************/
    /* constructor                                                          */
    /************************************************************************/
    public InGame()
    {
      mEngine = null;
    }

    /************************************************************************/
    /* start up                                                             */
    /************************************************************************/
    public override bool Startup( StateManager _mgr )
    {
        // store reference to engine, this state does not need to store the state manager reference
        mEngine = _mgr.Engine;

        if (File.Exists("map.txt"))
        {
            using (TextReader reader = File.OpenText("map.txt"))
            {

                /*byte[] buffer = new byte[1];
                while (fs.Read(buffer, 0, buffer.Length) > 0)
                {
                    if (byte[0] == '0') {
                        SceneNode tile = mEngine.CreateSimpleObject("Droit", "droit.mesh");
                        if (tile != null)
                        {
                            mMapTiles.Add(tile);
                            mEngine.AddObjectToScene(tile);
                        }
                    }
                }*/
            }
        }
        
        // OK
        return true;
    }

    private void CreateMap()
    {

    }

    /************************************************************************/
    /* shut down                                                            */
    /************************************************************************/
    public override void Shutdown()
    {
        foreach(SceneNode tile in mMapTiles)
        {
            mEngine.RemoveObjectFromScene(tile);
            mEngine.DestroyObject(tile);
        }
    }

    /************************************************************************/
    /* update                                                               */
    /************************************************************************/
    public override void Update( long _frameTime )
    {
      // check if ogre head exists
      /*if( mOgreHead != null )
      {
        // rotate the ogre head a little bit
        mOgreHead.Rotate( Vector3.UNIT_Y, new Radian( new Degree( 0.5f ) ) );
      }*/
    }

  } // class

} // namespace
