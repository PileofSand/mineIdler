namespace GameCode.MineLevel
{
    public class MineLevelController
    {
        private readonly MineLevelView _view;
        private readonly MineLevelModel _model;

        public MineLevelController(MineLevelView view, MineLevelModel model)
        {
            _view = view;
            _model = model;
        }

        public void SetLevelActive( bool active)
        {
            _view.gameObject.SetActive(active);
            _model.IsActive = active;
        }

        public MineLevelModel GetModel()
        {
            return _model;
        }

        public MineLevelView GetView()
        {
            return _view;
        }
    }
}