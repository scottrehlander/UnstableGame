#ifndef __Unstable_h_
#define __Unstable_h_


#include "UnstableApplication.h"
#include "UnstableFrameListener.h"
#if OGRE_PLATFORM == OGRE_PLATFORM_WIN32
#include "../res/resource.h"
#include "../../SceneManager/ImmovableSceneManager.h"
#endif

using namespace Unstable_ImmovableSceneManager;

class UnstableApp : public UnstableApplication
{
	public:
		UnstableApp() {}
		virtual void createScene(void)
		{
			ImmovableSceneManager* s = new ImmovableSceneManager(mSceneMgr);
		}

	~UnstableApp()
	{
	}

protected:

	virtual void createCamera(void)
	{

		// Create the camera
		mCamera = mSceneMgr->createCamera("PlayerCam");

		// Position it at 500 in Z direction
		mCamera->setPosition(Vector3(0,0,80));
		// Look back along -Z
		mCamera->lookAt(Vector3(0,0,-300));
		mCamera->setNearClipDistance(5);
	}


    virtual bool configure(void)
    {
        // Show the configuration dialog and initialise the system
        // You can skip this and use root.restoreConfig() to load configuration
        // settings if you were sure there are valid ones saved in ogre.cfg
		if(mRoot->showConfigDialog())
        {
            // If returned true, user clicked OK so initialise
            // Here we choose to let the system create a default rendering window by passing 'true'
            mWindow = mRoot->initialise(true);
			// Let's add a nice window icon
#if OGRE_PLATFORM == OGRE_PLATFORM_WIN32
			HWND hwnd;
			mWindow->getCustomAttribute("WINDOW", (void*)&hwnd);
			LONG iconID   = (LONG)LoadIcon( GetModuleHandle(0), MAKEINTRESOURCE(IDI_APPICON) );
			SetClassLong( hwnd, GCL_HICON, iconID );
#endif
            return true;
        }
        else
        {
            return false;
        }
    }


	// Just override the mandatory create scene method
	//virtual void createScene(void)
	//{
	//	Entity* ogreHead = mSceneMgr->createEntity("Head", "ogrehead.mesh");

	//	SceneNode* headNode = mSceneMgr->getRootSceneNode()->createChildSceneNode();
	//	headNode->attachObject(ogreHead);

	//	// Set ambient light
	//	mSceneMgr->setAmbientLight(ColourValue(0.5, 0.5, 0.5));

	//	// Create a light
	//	Light* l = mSceneMgr->createLight("MainLight");
	//	l->setPosition(20,80,50);
	//}

   // Create new frame listener
	void createFrameListener(void)
	{
		mFrameListener= new UnstableFrameListener(mSceneMgr, mWindow, mCamera);
		mRoot->addFrameListener(mFrameListener);
	}
};

#endif // #ifndef __Unstable_h_