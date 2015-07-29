var RecipeList = React.createClass({
    loadRecipesFromServer: function () {
        var xhr = new XMLHttpRequest();
        xhr.open('get', this.props.url, true);
        xhr.onload = function () {
            var data = JSON.parse(xhr.responseText);
            this.setState({ data: data });
        }.bind(this);
        xhr.send();
    },
    getInitialState: function () {
        return { data: this.props.initialData };
    },
    componentDidMount: function () {
        window.setInterval(this.loadRecipesFromServer, this.props.pollInterval);
    },
    render: function () {
        var recipeNodes = this.state.data.map(function (recipe) {
            return (
              <RecipeCard data={recipe}></RecipeCard>
          );
        });
        return React.createElement('div', { className: "recipeList ui link cards" },
        { recipeNodes }
      )
    }
});

var RecipeCard = React.createClass({
    render: function () {
        var recipe = this.props.data;
        if (!recipe.ImageUrl) {
            recipe.ImageUrl = "http://semantic-ui.com/images/wireframe/image.png";
        }
        recipe.Url = '/recipes/' + recipe.Id

        return (<div className="card">
        <a className="content">
            <img className="ui avatar image" src="http://semantic-ui.com/images/avatar/large/elliot.jpg" /> Author Name
        </a>
        <a className="image" href={recipe.Url}>
            <img src={recipe.ImageUrl} alt={recipe.Name} />
        </a>
        <div className="content">
            <a className="header" href={recipe.Url}>{recipe.Name}</a>
            <div className="description">
                {recipe.Intro}
            </div>
        </div>
        <div className="extra content">
            <span className="right floated">
              <i className="heart outline like icon"></i> 17 likes
            </span>
            <i className="comment icon"></i> 3 comments
        </div>
        </div>)
    }
});

//React.render(
//  <RecipeList url="/recipes/all" pollInterval={2000} submitUrl="/recipes/new" />,
//  document.getElementById('recipes')
//);