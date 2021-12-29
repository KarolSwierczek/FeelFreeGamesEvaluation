// GENERATED AUTOMATICALLY FROM 'Assets/Input/DefaultInputActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace FeelFreeGames.Evaluation.Input
{
    public class @DefaultInputActions : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @DefaultInputActions()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""DefaultInputActions"",
    ""maps"": [
        {
            ""name"": ""Inventory"",
            ""id"": ""78e3acb5-01ff-4429-b52a-2afa013a5f1d"",
            ""actions"": [
                {
                    ""name"": ""Navigate"",
                    ""type"": ""Value"",
                    ""id"": ""049b5d54-2697-4728-b0e2-0b66f21d729f"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PickUpOrDrop"",
                    ""type"": ""Button"",
                    ""id"": ""b590a84a-26be-45b8-950f-c4e57c4835ec"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""DrawItemsOrDelete"",
                    ""type"": ""Button"",
                    ""id"": ""33ff0363-4465-4511-b188-ef52f24e2051"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Cancel"",
                    ""type"": ""Button"",
                    ""id"": ""d4c98b01-e97c-40ea-8ce9-dd657cb6d16d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Gamepad"",
                    ""id"": ""809f371f-c5e2-4e7a-83a1-d867598f40dd"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""14a5d6e8-4aaf-4119-a9ef-34b8c2c548bf"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""up"",
                    ""id"": ""9144cbe6-05e1-4687-a6d7-24f99d23dd81"",
                    ""path"": ""<Gamepad>/rightStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""2db08d65-c5fb-421b-983f-c71163608d67"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""58748904-2ea9-4a80-8579-b500e6a76df8"",
                    ""path"": ""<Gamepad>/rightStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""8ba04515-75aa-45de-966d-393d9bbd1c14"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""712e721c-bdfb-4b23-a86c-a0d9fcfea921"",
                    ""path"": ""<Gamepad>/rightStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""fcd248ae-a788-4676-a12e-f4d81205600b"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""1f04d9bc-c50b-41a1-bfcc-afb75475ec20"",
                    ""path"": ""<Gamepad>/rightStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""fb8277d4-c5cd-4663-9dc7-ee3f0b506d90"",
                    ""path"": ""<Gamepad>/dpad"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""ff527021-f211-4c02-933e-5976594c46ed"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""563fbfdd-0f09-408d-aa75-8642c4f08ef0"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""up"",
                    ""id"": ""eb480147-c587-4a33-85ed-eb0ab9942c43"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""2bf42165-60bc-42ca-8072-8c13ab40239b"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""85d264ad-e0a0-4565-b7ff-1a37edde51ac"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""74214943-c580-44e4-98eb-ad7eebe17902"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""cea9b045-a000-445b-95b8-0c171af70a3b"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""8607c725-d935-4808-84b1-8354e29bab63"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""4cda81dc-9edd-4e03-9d7c-a71a14345d0b"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""3497d241-040b-4c28-bb87-9ec6d5fd2d9b"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PickUpOrDrop"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e7a8242e-15ea-4056-949e-a5af2632cfe6"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PickUpOrDrop"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2cebcd40-3479-4cdd-be5a-daf33f4076b2"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DrawItemsOrDelete"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""012eff20-7748-474d-828f-4cc4d3dedc8c"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DrawItemsOrDelete"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3ef924e6-5349-44e1-ba36-f831f0a1eb02"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d0eb1afb-37fd-4b9f-b3d2-cb94ea6f3789"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Game"",
            ""id"": ""8663a7a2-a6a3-4bd0-8cb2-87eacf2847f6"",
            ""actions"": [
                {
                    ""name"": ""NextResolution"",
                    ""type"": ""Button"",
                    ""id"": ""a67a1542-8ad1-4a74-900d-782f7db9bf3a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PrevResolution"",
                    ""type"": ""Button"",
                    ""id"": ""3e83dc86-e06d-4c57-80d8-a984b1974cdb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""be287512-7a6f-41e5-a6e1-8859014b6356"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NextResolution"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2783d3fa-5164-4d78-9896-94ca82d811a5"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NextResolution"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6573f775-d890-4218-ace4-1a072197b458"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PrevResolution"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0d9f3fe9-f079-4ba1-80d0-160bab9af7a6"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PrevResolution"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard&Mouse"",
            ""bindingGroup"": ""Keyboard&Mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Touch"",
            ""bindingGroup"": ""Touch"",
            ""devices"": [
                {
                    ""devicePath"": ""<Touchscreen>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Joystick"",
            ""bindingGroup"": ""Joystick"",
            ""devices"": [
                {
                    ""devicePath"": ""<Joystick>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""XR"",
            ""bindingGroup"": ""XR"",
            ""devices"": [
                {
                    ""devicePath"": ""<XRController>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
            // Inventory
            m_Inventory = asset.FindActionMap("Inventory", throwIfNotFound: true);
            m_Inventory_Navigate = m_Inventory.FindAction("Navigate", throwIfNotFound: true);
            m_Inventory_PickUpOrDrop = m_Inventory.FindAction("PickUpOrDrop", throwIfNotFound: true);
            m_Inventory_DrawItemsOrDelete = m_Inventory.FindAction("DrawItemsOrDelete", throwIfNotFound: true);
            m_Inventory_Cancel = m_Inventory.FindAction("Cancel", throwIfNotFound: true);
            // Game
            m_Game = asset.FindActionMap("Game", throwIfNotFound: true);
            m_Game_NextResolution = m_Game.FindAction("NextResolution", throwIfNotFound: true);
            m_Game_PrevResolution = m_Game.FindAction("PrevResolution", throwIfNotFound: true);
        }

        public void Dispose()
        {
            UnityEngine.Object.Destroy(asset);
        }

        public InputBinding? bindingMask
        {
            get => asset.bindingMask;
            set => asset.bindingMask = value;
        }

        public ReadOnlyArray<InputDevice>? devices
        {
            get => asset.devices;
            set => asset.devices = value;
        }

        public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

        public bool Contains(InputAction action)
        {
            return asset.Contains(action);
        }

        public IEnumerator<InputAction> GetEnumerator()
        {
            return asset.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Enable()
        {
            asset.Enable();
        }

        public void Disable()
        {
            asset.Disable();
        }

        // Inventory
        private readonly InputActionMap m_Inventory;
        private IInventoryActions m_InventoryActionsCallbackInterface;
        private readonly InputAction m_Inventory_Navigate;
        private readonly InputAction m_Inventory_PickUpOrDrop;
        private readonly InputAction m_Inventory_DrawItemsOrDelete;
        private readonly InputAction m_Inventory_Cancel;
        public struct InventoryActions
        {
            private @DefaultInputActions m_Wrapper;
            public InventoryActions(@DefaultInputActions wrapper) { m_Wrapper = wrapper; }
            public InputAction @Navigate => m_Wrapper.m_Inventory_Navigate;
            public InputAction @PickUpOrDrop => m_Wrapper.m_Inventory_PickUpOrDrop;
            public InputAction @DrawItemsOrDelete => m_Wrapper.m_Inventory_DrawItemsOrDelete;
            public InputAction @Cancel => m_Wrapper.m_Inventory_Cancel;
            public InputActionMap Get() { return m_Wrapper.m_Inventory; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(InventoryActions set) { return set.Get(); }
            public void SetCallbacks(IInventoryActions instance)
            {
                if (m_Wrapper.m_InventoryActionsCallbackInterface != null)
                {
                    @Navigate.started -= m_Wrapper.m_InventoryActionsCallbackInterface.OnNavigate;
                    @Navigate.performed -= m_Wrapper.m_InventoryActionsCallbackInterface.OnNavigate;
                    @Navigate.canceled -= m_Wrapper.m_InventoryActionsCallbackInterface.OnNavigate;
                    @PickUpOrDrop.started -= m_Wrapper.m_InventoryActionsCallbackInterface.OnPickUpOrDrop;
                    @PickUpOrDrop.performed -= m_Wrapper.m_InventoryActionsCallbackInterface.OnPickUpOrDrop;
                    @PickUpOrDrop.canceled -= m_Wrapper.m_InventoryActionsCallbackInterface.OnPickUpOrDrop;
                    @DrawItemsOrDelete.started -= m_Wrapper.m_InventoryActionsCallbackInterface.OnDrawItemsOrDelete;
                    @DrawItemsOrDelete.performed -= m_Wrapper.m_InventoryActionsCallbackInterface.OnDrawItemsOrDelete;
                    @DrawItemsOrDelete.canceled -= m_Wrapper.m_InventoryActionsCallbackInterface.OnDrawItemsOrDelete;
                    @Cancel.started -= m_Wrapper.m_InventoryActionsCallbackInterface.OnCancel;
                    @Cancel.performed -= m_Wrapper.m_InventoryActionsCallbackInterface.OnCancel;
                    @Cancel.canceled -= m_Wrapper.m_InventoryActionsCallbackInterface.OnCancel;
                }
                m_Wrapper.m_InventoryActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Navigate.started += instance.OnNavigate;
                    @Navigate.performed += instance.OnNavigate;
                    @Navigate.canceled += instance.OnNavigate;
                    @PickUpOrDrop.started += instance.OnPickUpOrDrop;
                    @PickUpOrDrop.performed += instance.OnPickUpOrDrop;
                    @PickUpOrDrop.canceled += instance.OnPickUpOrDrop;
                    @DrawItemsOrDelete.started += instance.OnDrawItemsOrDelete;
                    @DrawItemsOrDelete.performed += instance.OnDrawItemsOrDelete;
                    @DrawItemsOrDelete.canceled += instance.OnDrawItemsOrDelete;
                    @Cancel.started += instance.OnCancel;
                    @Cancel.performed += instance.OnCancel;
                    @Cancel.canceled += instance.OnCancel;
                }
            }
        }
        public InventoryActions @Inventory => new InventoryActions(this);

        // Game
        private readonly InputActionMap m_Game;
        private IGameActions m_GameActionsCallbackInterface;
        private readonly InputAction m_Game_NextResolution;
        private readonly InputAction m_Game_PrevResolution;
        public struct GameActions
        {
            private @DefaultInputActions m_Wrapper;
            public GameActions(@DefaultInputActions wrapper) { m_Wrapper = wrapper; }
            public InputAction @NextResolution => m_Wrapper.m_Game_NextResolution;
            public InputAction @PrevResolution => m_Wrapper.m_Game_PrevResolution;
            public InputActionMap Get() { return m_Wrapper.m_Game; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(GameActions set) { return set.Get(); }
            public void SetCallbacks(IGameActions instance)
            {
                if (m_Wrapper.m_GameActionsCallbackInterface != null)
                {
                    @NextResolution.started -= m_Wrapper.m_GameActionsCallbackInterface.OnNextResolution;
                    @NextResolution.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnNextResolution;
                    @NextResolution.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnNextResolution;
                    @PrevResolution.started -= m_Wrapper.m_GameActionsCallbackInterface.OnPrevResolution;
                    @PrevResolution.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnPrevResolution;
                    @PrevResolution.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnPrevResolution;
                }
                m_Wrapper.m_GameActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @NextResolution.started += instance.OnNextResolution;
                    @NextResolution.performed += instance.OnNextResolution;
                    @NextResolution.canceled += instance.OnNextResolution;
                    @PrevResolution.started += instance.OnPrevResolution;
                    @PrevResolution.performed += instance.OnPrevResolution;
                    @PrevResolution.canceled += instance.OnPrevResolution;
                }
            }
        }
        public GameActions @Game => new GameActions(this);
        private int m_KeyboardMouseSchemeIndex = -1;
        public InputControlScheme KeyboardMouseScheme
        {
            get
            {
                if (m_KeyboardMouseSchemeIndex == -1) m_KeyboardMouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard&Mouse");
                return asset.controlSchemes[m_KeyboardMouseSchemeIndex];
            }
        }
        private int m_GamepadSchemeIndex = -1;
        public InputControlScheme GamepadScheme
        {
            get
            {
                if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
                return asset.controlSchemes[m_GamepadSchemeIndex];
            }
        }
        private int m_TouchSchemeIndex = -1;
        public InputControlScheme TouchScheme
        {
            get
            {
                if (m_TouchSchemeIndex == -1) m_TouchSchemeIndex = asset.FindControlSchemeIndex("Touch");
                return asset.controlSchemes[m_TouchSchemeIndex];
            }
        }
        private int m_JoystickSchemeIndex = -1;
        public InputControlScheme JoystickScheme
        {
            get
            {
                if (m_JoystickSchemeIndex == -1) m_JoystickSchemeIndex = asset.FindControlSchemeIndex("Joystick");
                return asset.controlSchemes[m_JoystickSchemeIndex];
            }
        }
        private int m_XRSchemeIndex = -1;
        public InputControlScheme XRScheme
        {
            get
            {
                if (m_XRSchemeIndex == -1) m_XRSchemeIndex = asset.FindControlSchemeIndex("XR");
                return asset.controlSchemes[m_XRSchemeIndex];
            }
        }
        public interface IInventoryActions
        {
            void OnNavigate(InputAction.CallbackContext context);
            void OnPickUpOrDrop(InputAction.CallbackContext context);
            void OnDrawItemsOrDelete(InputAction.CallbackContext context);
            void OnCancel(InputAction.CallbackContext context);
        }
        public interface IGameActions
        {
            void OnNextResolution(InputAction.CallbackContext context);
            void OnPrevResolution(InputAction.CallbackContext context);
        }
    }
}
