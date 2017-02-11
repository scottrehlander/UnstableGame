#ifndef __ImmovableSceneManager_h_
#define __ImmovableSceneManager_h_

#include "Ogre.h"
#include "OgreConfigFile.h"

namespace Unstable_ImmovableSceneManager
{
	using namespace Ogre;

	class ImmovableSceneManager
	{
		public:
			ImmovableSceneManager(SceneManager* sceneManager_) 
			{
				sceneManager = sceneManager_;
				createScene();
			}

			void createScene()
			{

					//Entity* ogreHead = sceneManager->createEntity("Head", "man.mesh");

					//SceneNode* headNode = sceneManager->getRootSceneNode()->createChildSceneNode();
					//headNode->attachObject(ogreHead);

					//// Set ambient light
					//sceneManager->setAmbientLight(ColourValue(0.5, 0.5, 0.5));

					//// Create a light
					//Light* l = sceneManager->createLight("MainLight");
					//l->setPosition(20,80,50);
				Entity *ent;

				sceneManager->setAmbientLight( ColourValue( 0, 0, 0 ) );
				sceneManager->setShadowTechnique( SHADOWTYPE_STENCIL_ADDITIVE );
		        
				ent = sceneManager->createEntity("Ninja", "man.mesh");
				ent->setCastShadows(true);
				sceneManager->getRootSceneNode()->createChildSceneNode()->attachObject(ent);

				Plane plane(Vector3::UNIT_Y, 0);

				MeshManager::getSingleton().createPlane("ground",
					ResourceGroupManager::DEFAULT_RESOURCE_GROUP_NAME, plane,
					1500,1500,20,20,true,1,5,5,Vector3::UNIT_Z);

				ent = sceneManager->createEntity("GroundEntity", "ground");
				sceneManager->getRootSceneNode()->createChildSceneNode()->attachObject(ent);

				ent->setMaterialName("Examples/Rockwall");
				ent->setCastShadows(false);

				createLights();
			}

			void createLights()
			{
				Light *light;
				light = sceneManager->createLight("Light1");
				light->setType(Light::LT_POINT);
				light->setPosition(Vector3(0, 150, 250));

				light->setDiffuseColour(1.0, 0.0, 0.0);
				light->setSpecularColour(1.0, 0.0, 0.0);

				light = sceneManager->createLight("Light3");
				light->setType(Light::LT_DIRECTIONAL);
				light->setDiffuseColour(ColourValue(.25, .25, 0));
				light->setSpecularColour(ColourValue(.25, .25, 0));

				light->setDirection(Vector3( 0, -1, 1 )); 

				light = sceneManager->createLight("Light2");
				light->setType(Light::LT_SPOTLIGHT);
				light->setDiffuseColour(0, 0, 1.0);
				light->setSpecularColour(0, 0, 1.0);

				light->setDirection(-1, -1, 0);
				light->setPosition(Vector3(300, 300, 0));

				light->setSpotlightRange(Degree(35), Degree(50));
			}

			~ImmovableSceneManager()
			{
			}

		protected:
			SceneManager* sceneManager;

	};
}
#endif // #ifndef __ImmovableSceneManager_h_