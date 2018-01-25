using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Runtime.InteropServices;

class Image
{
    #region Properties
    public Vector2 Position
    {
        get { return drawPosition; }
        set
        {
            drawPosition = value;
            CreateDrawRectangle();
        }
    }

    public Vector2 Dimensions
    {
        get { return drawDimensions; }
        set
        {
            drawDimensions = value;
            CreateDrawRectangle();
        }
    }

    public Vector2 Center
    {
        get { return Position + (Dimensions / 2); }
    }

    public bool Visible
    {
        get { return visible; }
        set { visible = value; }
    }

    public bool Active
    {
        get { return active; }
        set { active = value; }
    }

    public float Rotation
    {
        get { return rotation; }
        set { rotation = value; }
    }
    #endregion

    #region Variables
    protected Texture2D texture;
    protected SpriteBatch spriteBatch;
    protected Vector2 sourcePosition;
    protected Vector2 sourceDimensions;
    protected Rectangle sourceRectangle;
    protected Vector2 drawPosition;
    protected Vector2 drawDimensions;
    protected Rectangle drawRectangle;
    protected Color color;
    protected bool visible;
    protected bool active;
    protected float rotation;
    #endregion

    #region Constructors
    public Image(Texture2D texture, SpriteBatch spriteBatch, Vector2 sourcePosition, Vector2 sourceDimensions, Vector2 drawPosition, Vector2 drawDimensions, Color color, float rotation = 0f, bool visible = true, bool active = true)
    {
        this.texture = texture;
        this.spriteBatch = spriteBatch;
        this.sourcePosition = sourcePosition;
        this.sourceDimensions = sourceDimensions;
        this.drawPosition = drawPosition;
        this.drawDimensions = drawDimensions;
        this.color = color;
        this.visible = visible;
        this.active = active;
        this.rotation = rotation;

        CreateSourceRectangle();
        CreateDrawRectangle();
    }
    #endregion

    #region Public Methods
    public virtual void Update(GameTime gameTime)
    {
        // No op
    }

    public virtual void Draw()
    {
        if (!active || !visible)
            return;

        spriteBatch.Draw(texture, drawRectangle, sourceRectangle, color, rotation, Center, SpriteEffects.None, 0);
    }
    #endregion

    #region Protected Methods
    protected virtual void CreateSourceRectangle()
    {
        sourceRectangle = new Rectangle(sourcePosition.ToPoint(), sourceDimensions.ToPoint());
    }

    protected virtual void CreateDrawRectangle()
    {
        drawRectangle = new Rectangle(drawPosition.ToPoint(), drawDimensions.ToPoint());
    }
    #endregion
}