using FeelFreeGames.Evaluation.Data;
using FeelFreeGames.Evaluation.UI;
using Zenject;

namespace FeelFreeGames.Evaluation.Controllers
{
    public class AudioControllerBindings : IAudioControllerBindings
    {
        private readonly IAudioController _audioController;
        
        [Inject]
        public AudioControllerBindings(IAudioController audioController)
        {
            _audioController = audioController;
        }

        void IAudioControllerBindings.BindInventoryAudio(IInventoryEvents inventoryEvents)
        {
            inventoryEvents.ItemSelected += OnItemSelected;
            inventoryEvents.ItemDeleted += OnItemDeleted;
            inventoryEvents.NewItemsDrawn += OnNewItemsDrawn;
            inventoryEvents.ItemDropped += OnItemDropped;
            inventoryEvents.ItemSwapped += OnItemSwapped;
            inventoryEvents.ItemPickUpCancelled += OnItemPickUpCancelled;
            inventoryEvents.ItemPickedUp += OnItemPickedUp;
        }

        void IAudioControllerBindings.BindResolutionControllerAudio(IResolutionControllerEvents resolutionControllerEvents)
        {
            resolutionControllerEvents.ResolutionChanged += OnResolutionChanged;
        }

        void IAudioControllerBindings.UnbindInventoryAudio(IInventoryEvents inventoryEvents)
        {
            inventoryEvents.ItemSelected -= OnItemSelected;
            inventoryEvents.ItemDeleted -= OnItemDeleted;
            inventoryEvents.NewItemsDrawn -= OnNewItemsDrawn;
            inventoryEvents.ItemDropped -= OnItemDropped;
            inventoryEvents.ItemSwapped -= OnItemSwapped;
            inventoryEvents.ItemPickUpCancelled -= OnItemPickUpCancelled;
            inventoryEvents.ItemPickedUp -= OnItemPickedUp;
        }

        void IAudioControllerBindings.UnbindResolutionControllerAudio(IResolutionControllerEvents resolutionControllerEvents)
        {
            resolutionControllerEvents.ResolutionChanged -= OnResolutionChanged;
        }

        private void OnItemSelected(IItem item)
        {
            _audioController.PlayClipOfType(AudioClipType.Rollover);
        }

        private void OnItemDeleted()
        {
            _audioController.PlayClipOfType(AudioClipType.Delete);
        }
        
        private void OnNewItemsDrawn()
        {
            _audioController.PlayClipOfType(AudioClipType.Shuffle);
        }
        
        private void OnItemDropped()
        {
            _audioController.PlayClipOfType(AudioClipType.Place);
        }
        
        private void OnItemSwapped()
        {
            _audioController.PlayClipOfType(AudioClipType.Shuffle);
        }
        
        private void OnItemPickUpCancelled()
        {
            _audioController.PlayClipOfType(AudioClipType.Place);
        }
        
        private void OnItemPickedUp()
        {
            _audioController.PlayClipOfType(AudioClipType.Take);
        }

        private void OnResolutionChanged()
        {
            _audioController.PlayClipOfType(AudioClipType.Click);
        }
    }
}